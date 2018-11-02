const amqp = require('amqplib/callback_api');

const messageBrokerInfo = {
    exchanges: {
        math: 'math_exchange'
    },
    queues: {
        addQueue: 'add_queue'
    },
    routingKeys: {
        input: 'multiply_success',
        output: 'problem_solved'
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
    const { addQueue } = messageBrokerInfo.queues;
    const { input } = messageBrokerInfo.routingKeys;

    channel.assertExchange(math, 'direct', { durable: true });
    channel.assertQueue(addQueue, { durable: true });
    channel.bindQueue(addQueue, math, input);
};

const add = (a, b) => {
    return a + b;
};

// const add = (a, b) => a + b;

(async () => {
    const messageBrokerConnection = await createMessageBrokerConnection();
    const channel = await createChannel(messageBrokerConnection);

    configureMessageBroker(channel);

    const { math } = messageBrokerInfo.exchanges;
    const { addQueue } = messageBrokerInfo.queues;
    const { output } = messageBrokerInfo.routingKeys;

    channel.consume(addQueue, data => {
        const dataJson = JSON.parse(data.content.toString());
        const addResult = add(dataJson.a, dataJson.b);
        channel.publish(math, output, new Buffer(JSON.stringify(addResult)));
        console.log(`[x] Sent: ${addResult}`);
    }, { noAck: true });

})().catch(e => console.error(e));
