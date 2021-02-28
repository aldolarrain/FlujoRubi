namespace ApiProductor.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using ApiProductor.Models;
    using System.Text.Json;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            string connectionString = "<NAMESPACE CONNECTION STRING>";/////https://drive.google.com/file/d/1wFPVOVut24EA_myHs2VJgveBnQR4JKsP/view   FALTA ANADIR EL CONECTION STRING MINUTO 44 DEL VIDEO 
            string queueName = "<QUEUE NAME>"; /////FALTA 
            string mensaje = JsonConvert.SerializeObject(data);

            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }
            return true;
        }
    }
}

/////SIGUIENTE PASO FALTA PUBLICA COMO EN EL VIDEO MINUTO 27 https://drive.google.com/file/d/1_j5J4IBa921fxOkq0DPGGHc4Lx-8nm1w/view
