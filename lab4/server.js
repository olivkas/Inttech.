const { Kafka } = require('kafkajs')
const uuid = require('uuid/v4');

const kafka = new Kafka({
  clientId: 'my-app',
  brokers: ['localhost:9092'],
})

const producer = kafka.producer()
const consumer = kafka.consumer({ groupId: uuid() })
const user = `user_${Math.round(Math.random() * 1000)}`;

const run = async () => {
  // Producing
  await producer.connect()

  // Consuming
  await consumer.connect()
  await consumer.subscribe({ topic: 'message', fromBeginning: true })
 //lisen mess
  await consumer.run({
    eachMessage: async ({ message }) => {
      const data = JSON.parse(message.value.toString());
      if (user !== data.name) {
        console.log(`${data.name} : ${data.message}`);
      }
    },
  })
}

run().catch(console.error)


process.stdin.setEncoding('utf8');

process.stdin.on('readable', () => {
let chunk;
while ((chunk = process.stdin.read()) !== null) {
  producer.send({
    topic: 'message',
    messages: [
      { value: JSON.stringify({ name: user, message: chunk }) },
    ],
  })
}
});