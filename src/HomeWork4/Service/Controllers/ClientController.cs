using Commands.Interfaces;
using Data.Request;
using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using RabbitClient.Publishers;
using Requests.Request;
using Service.Publishers;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICreateClientPublisher _createPublish;
        private readonly IGetClientPublisher _getPublish;
        private readonly IDeleteClientPublisher _deletePublish;
        private readonly IUpdateClientPublisher _updatePublish;

        public ClientController(
            ICreateClientPublisher createPublish,
            IGetClientPublisher getPublish,
            IDeleteClientPublisher deletePublish,
            IUpdateClientPublisher updatePublish)
        {
            _createPublish = createPublish;
            _getPublish = getPublish;
            _deletePublish = deletePublish;
            _updatePublish = updatePublish;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
        [FromBody] CreateClientRequest request)
        {
            CreateClientResponse response = await _createPublish.CreateClientAsync(request);

            if (response.Errors is not null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
        [FromQuery] GetClientRequest request)
        {
            GetClientResponse response = await _getPublish.GetClientAsync(request);

            if (response.Errors is not null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
        [FromQuery] DeleteClientRequest request)
        {
            DeleteClientResponse response = await _deletePublish.DeleteClientAsync(request);

            if (response.Errors is not null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
        [FromQuery] Guid id,
        [FromBody] UpdateClientRequest request)
        {
            UpdateClientResponse response = await _updatePublish.UpdateClientAsync(request, id);

            if (response.Errors is not null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
