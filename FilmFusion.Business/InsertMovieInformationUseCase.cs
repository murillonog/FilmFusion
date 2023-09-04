using FilmFusion.Domain.Entities;
using FilmFusion.Domain.Repositories;
using FilmFusion.Domain.UseCases;
using Microsoft.Extensions.Logging;

namespace FilmFusion.Business
{
    public class InsertMovieInformationUseCase : IInsertMovieInformationUseCase
    {
        private readonly ILogger<InsertMovieInformationUseCase> _logger;
        private readonly IRepositoryBase<Entertainment> _entertainmentRepository;

        public InsertMovieInformationUseCase(ILogger<InsertMovieInformationUseCase> logger,
            IRepositoryBase<Entertainment> entertainmentRepository)
        {
            _logger = logger;
            _entertainmentRepository = entertainmentRepository;
        }

        public async Task<bool> InsertMovieSqlServer(Entertainment entertainment)
        {
            _logger.LogInformation($"{DateTime.Now} | Try Insert {entertainment.Title} in SQL SERVER: BEGIN");            
            
            if (await _entertainmentRepository.Exists(m => m.ImdbId == entertainment.ImdbId) != null)
            {
                _logger.LogInformation($"{DateTime.Now} | {entertainment.Title} exists in SQL SERVER");
                return false;
            }

            await _entertainmentRepository.AddAsync(entertainment);
            await _entertainmentRepository.SaveChangesAsync();
            _logger.LogInformation($"{DateTime.Now} | Try Insert {entertainment.Title} in SQL SERVER: END");
            return true;
        }
    }
}
