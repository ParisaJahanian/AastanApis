﻿using AasanApis.Data.Entities;
using AasanApis.ErrorHandling;
using AasanApis.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace AasanApis.Data.Repositories
{
    public class BaseRepository :IBaseRepository
    {
        private AasanDbContext _dbContext { get; set; }
        private ILogger<BaseRepository> _logger;
        public BaseRepository(AasanDbContext dbContext,
            ILogger<BaseRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<string> FindAccessToken()
        {
            var query = await _dbContext.AccessTokens.
                SingleOrDefaultAsync(i => i.Id == "7")
                .ConfigureAwait(false);
            return query?.AccessToken ?? string.Empty;
        }
        public async Task<AccessTokenEntity> AddOrUpdateTokenAsync(string? accessToken)
        {
            var query = _dbContext.AccessTokens.SingleOrDefault(i => i.Id == "7");
            if (query is null)
            {
                query = new AccessTokenEntity();
                query.Id = "7";
                query.TokenName = "AasanToken";
                await _dbContext.AccessTokens.AddAsync(query).ConfigureAwait(false);
            }
            query.AccessToken = accessToken;
            query.TokenDateTime = DateTime.UtcNow;
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,
                    $"{nameof(AddOrUpdateTokenAsync)} -> applyUpdateToken in AddOrUpdateTokenAsync couldn't update.");
                throw new RamzNegarException(ErrorCode.AasanTokenApiError,
                    $"Exception occurred while: {nameof(AddOrUpdateTokenAsync)}  => {ErrorCode.AasanTokenApiError.GetDisplayName()}");
            }

            return query;
        }
    }
}