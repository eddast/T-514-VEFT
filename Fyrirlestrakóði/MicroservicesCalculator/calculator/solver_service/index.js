const amqp = require('amqplib/callback_api');
const fs = require('fs');
const moment = require('moment');

const messageBrokerInfo = {
    exchanges: {
        math: 'math_exchange'
    },
    queues: {
        solvedProblemsQueue: 'solved_problems_queue'
    },
    routingKeys: {
        problemSolved: 'problem_solved'
    }
}

const createMessageBrokerConnection = () => new Promise((resolve, reject) => {
    amqp.connect('amqp://localhost', (err, conn) => {
        if (err) { reject(err); }
        resolve(conn);
    });
});

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
        if (err) { reject(err); }
        resolve(channel);
    });
});

const configureMessageBroker = channel => {
    const { math } = messageBrokerInfo.exchanges;
    const { solvedProblemsQueue } = messageBrokerInfo.queues;
    const { problemSolved } = messageBrokerInfo.routingKeys;

    channel.assertExchange(math, 'direct', { durable: true });
    channel.assertQueue(solvedProblemsQueue, { durable: true });
    channel.bindQueue(solvedProblemsQueue, math, problemSolved);
};

(async () => {
    const messageBrokerConnection = await createMessageBrokerConnection();
    const channel = await createChannel(messageBrokerConnection);

    configureMessageBroker(channel);

    const { math } = messageBrokerInfo.exchanges;
    const { solvedProblemsQueue } = messageBrokerInfo.queues;
    const { output } = messageBrokerInfo.routingKeys;

    channel.consume(solvedProblemsQueue, data => {
        fs.appendFile('solved_problems.txt', `Solved: ${data.content.toString()} @ ${moment().format('llll')} \n`, err => {
            if (err) { console.error(err); }
            else { console.log('Problem solved!'); }
        });
    }, { noAck: true });

})().catch(e => console.error(e));
