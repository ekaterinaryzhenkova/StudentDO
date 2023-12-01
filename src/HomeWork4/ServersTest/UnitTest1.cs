using Commands.Client;
using Data.Mappers.Interfaces;
using Data.Repositories.Interfaces;
using Data.Validators;
using Moq;
using Requests.Request;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using DbModels;
using FluentValidation;
using Data.Responses;

namespace ServersTest
{
    public class CreateClientTest
    {
        private Mock<ICreateClientRequestValidator> _validator;
        private Mock<IClientRepository> _repository;
        private Mock<IClientMapper> _mapper;

        private CreateClientCommand _command;
        DbClient _dbClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _validator = new Mock<ICreateClientRequestValidator>();
            _repository = new Mock<IClientRepository>();
            _mapper = new Mock<IClientMapper>();

           /* _validator
              .Setup(x => x.Validate(null))
              .Returns(new FluentValidation.Results.ValidationResult()
              {
                  Errors = new()
                  {
                      new ValidationFailure()
                  }
              });

            _validator
              .Setup(x => x.Validate(It.IsAny<CreateClientRequest>()))
              .Returns(new FluentValidation.Results.ValidationResult());

            _repository
                 .Setup(x => x.CreateClient(It.IsAny<DbClient>()));*/

            _dbClient = new()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                PhoneNumber = "89006777064",
            };

            /*_mapper
                .Setup(x => x.Map(It.IsAny<CreateClientRequest>()))
                .Returns(_dbClient);

            _command = new CreateClientCommand(
                _repository.Object,
                _mapper.Object,
                _validator.Object);*/
        }

        [Test]
        public async Task ReturnErrorsNotNullWhenRequestIsOk()
        {
            CreateClientResponse response = new()
            {
                ClientId = _dbClient.Id,
            };

            var request = new CreateClientRequest
            {
                Name = "test",
                PhoneNumber = "89006777064"
            };

            _validator
              .Setup(x => x.Validate(It.IsAny<CreateClientRequest>()))
              .Returns(new FluentValidation.Results.ValidationResult());

            _mapper
                .Setup(x => x.Map(It.IsAny<CreateClientRequest>()))
                .Returns(_dbClient);

            _repository
                .Setup(x => x.CreateClientAsync(It.IsAny<DbClient>()));

            var actualResult = await _command.CreateClientAsync(request);

            Assert.AreEqual(actualResult, response);
        }

        [Test]
        public async Task ReturnErrorsEqualsNullWhenRequestIsNotOk()
        {
            CreateClientRequest request = null;

            var actualResult = await _command.CreateClientAsync(request);

            Assert.IsNull(actualResult.Errors);
        }
    }
}