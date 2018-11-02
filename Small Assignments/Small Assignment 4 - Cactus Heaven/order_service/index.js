const amqp = require('amqplib/callback_api');
const { Order, OrderItem } = require('./data/db');

const messageBrokerInfo = {
    exchanges: { order: 'order_exchange' },
    queues: { orderQueue: 'order_queue' },
    routingKeys: { createOrder: 'create_order' }
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

const createResourcesIntoDB = data => {
    // Attempt to create order
    let order = new Order({
        customerEmail: data.email,
        totalPrice: data.items.reduce((prev, curr) => prev + (curr.quantity * curr.unitPrice), 0),
        orderDate: new Date()
    });
    order.save((error, newOrder) => {
        if(error) console.log(`[x] Failed to add order for customer ${data.email !== undefined ? '' : data.email} to database`);
        else {
            // attempt to create order items
            const { items } = data;
            if(items && Array.isArray(items)) {
                for(let i = 0; i < items.length; i++) {
                    OrderItem.create({
                        description: items[i].description,
                        quantity: items[i].quantity,
                        unitPrice: items[i].unitPrice,
                        rowPrice: items[i].quantity * items[i].unitPrice,
                        orderId: newOrder._id
                        }, error => {
                            if(error) console.log(`[x] Failed to add some order item/s to database`);
                            else console.log(`[x] Added customer order and order item/s to database`)
                        }
                    );
                }
            } else console.log(`[x] Failed to add order items to database (order items improperly formatted)`);
        }
    });
}

(async () => {
    console.log(`Order service running`);
    const messageBrokerConnection = await createMessageBrokerConnection();
    const channel = await createChannel(messageBrokerConnection);
    configureMessageBroker(channel);
    const { addQueue } = messageBrokerInfo.queues;
    channel.consume(addQueue, data => {
        const dataJson = JSON.parse(data.content.toString());
        console.log(`[x] Adding items and order information for customer ${dataJson.email !== undefined ? '' : dataJson.email} to database`);
        createResourcesIntoDB(dataJson);
    }, { noAck: true });

})().catch(e => console.error(e));