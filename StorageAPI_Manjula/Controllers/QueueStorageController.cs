using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageAPI_Manjula.Services;

namespace StorageAPI_Manjula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueStorageController : ControllerBase
    {
        private const string QUEUE_NAME = "message-queue";
        private readonly IQueueStorage _queueService;
        public QueueStorageController(IQueueStorage queueService)
        {
            _queueService = queueService ?? throw new ArgumentNullException(nameof(queueService));
        }

        [Route("Send")]
        [HttpPost]
        public async Task<bool> Send(string queueMessage)
        {
            await _queueService.SendMessage(QUEUE_NAME, queueMessage);
            return true;
        }
        [Route("Receive")]
        [HttpGet]
        public async Task<List<string>> Receive()
        {
            return await _queueService.ReceiveMessages(QUEUE_NAME);

        }
        [Route("Update")]
        [HttpPut]
        public IActionResult Update()
        {
            _queueService.UpdateMessage(QUEUE_NAME);
            return Ok();
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete()
        {
            _queueService.DeleteMessage(QUEUE_NAME);
            return Ok();
        }
    }
}
