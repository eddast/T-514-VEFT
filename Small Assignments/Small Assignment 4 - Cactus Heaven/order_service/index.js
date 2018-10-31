const amqp = require('amqplib/callback_api');

const messageBrokerInfo = {
    exchanges: {
        order: 'order_exchange'
    },
    queues: {
        orderQueue: 'order_queue'
    },
    routingKeys: {
        createOrder: 'create_order'
    }
}

const createMessageBrokerConnection = () => new Promise((resolve, reject) => 
    amqp.connect('amqp://localhost', (err, conn) => err ? reject(err) : resolve(conn)));

const createChannel = connection => new Promise((resolve, reject) => 
    connection.createChannel((err, channel) => err ? reject(err) : resolve(channel)));

const configureMessageBroker = channel => {
    const { order } = messageBrokerInfo.exchanges;
    const { orderQueue } = messageBrokerInfo.queues;
    const { createOrder } = messageBrokerInfo.routingKeys;

    channel.assertExchange(order, 'direct', { durable: true });
    channel.assertQueue(orderQueue, { durable: true });
    channel.bindQueue(orderQueue, order, createOrder);
};

(async () => {
    console.log(`Order service running`);
    const messageBrokerConnection = await createMessageBrokerConnection();
    const channel = await createChannel(messageBrokerConnection);
    configureMessageBroker(channel);
    const { addQueue } = messageBrokerInfo.queues;
    channel.consume(addQueue, data => {
        const dataJson = JSON.parse(data.content.toString());
        console.log(`[x] Added items and order information for customer ${dataJson.email} to database`);
    }, { noAck: true });

})().catch(e => console.error(e));