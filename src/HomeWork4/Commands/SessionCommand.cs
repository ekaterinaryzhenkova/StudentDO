using Commands.Interfaces;
using Data.Mappers.Interfaces;
using Data.Repositories.Interfaces;
using Data.Validators.Interfaces;
using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Requests.Request;

namespace CLient
{
    public class SessionCommand : ISessionCommand
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ISessionMapper _sessionMapper;
        private readonly ISessionRequestValidator _sessionRequestValidator;

        public SessionCommand(
            ISessionRepository sessionRepository,
            ISessionMapper sessionMapper,
            ISessionRequestValidator sessionRequestValidator)
        {
            _sessionRepository = sessionRepository;
            _sessionMapper = sessionMapper;
            _sessionRequestValidator = sessionRequestValidator;
        }

        public IActionResult CreateSession(SessionRequest request)
        {
            ValidationResult validationResult = _sessionRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbSession session = _sessionMapper.Map(request);
            _sessionRepository.CreateSession(session);

            return new OkObjectResult(session.Id);
        }

        public IActionResult DeleteSession(Guid id)
        {
            _sessionRepository.DeleteSession(id);

            return new OkResult();
        }

        public IActionResult GetSession(Guid id)
        {
            DbSession? dbSession = _sessionRepository.GetSession(id);

            if (dbSession is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(dbSession);
        }

        public IActionResult GetSessions()
        {
            List<DbSession>? _sessions = _sessionRepository.GetSessions();

            if( _sessions is null )
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(_sessions);
        }

        public IActionResult UpdateSession(SessionRequest request, Guid id)
        {
            DbSession? dbSession = _sessionRepository.GetSession(id);

            if (dbSession is null)
            {
                return new NotFoundResult();
            }

            ValidationResult validationResult = _sessionRequestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            DbSession session = _sessionMapper.Map(request, id);

            _sessionRepository.EditSession(session);

            return new OkResult();
        }
    }
}

