using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using CSharpFunctionalExtensions;
using Dapper;
using DS.Application.Database;
using DS.Domain.Locations;
using DS.Infrastructure.Database;
using Microsoft.Extensions.Logging;

namespace DS.Infrastructure.Postgres.Repositories;

public class NpgSqlLocationsRepository : ILocationRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly ILogger<NpgSqlLocationsRepository> _logger;

    public NpgSqlLocationsRepository (IDbConnectionFactory connectionFactory, ILogger<NpgSqlLocationsRepository> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    public async Task<Result<Guid>> Add(Location location, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            const string locationInsertSql = """
                                             INSERT INTO locations (address, id, created_at, is_active, updated_at, location_name, iana_code)
                                             VALUES (@Address::jsonb, @Id, @CreatedAt, @IsActive, @UpdatedAt, @LocationName, @IanaCode)
                                             """;
            
            var locationInsertParams = new
            {
                Address = JsonSerializer.Serialize(location.Address),
                Id = location.Id,
                CreatedAt = location.CreatedAt,
                IsActive = location.IsActive,
                UpdatedAt = location.UpdatedAt,
                LocationName = location.Name.Name,
                IanaCode = location.Timezone.IanaCode,
            };

            await connection.ExecuteAsync(locationInsertSql, locationInsertParams);

            transaction.Commit();

            return Result.Success(location.Id);
        }
        catch(Exception ex)
        {
            transaction.Rollback();

            _logger.LogError(ex, ex.Message);

            return Result.Failure<Guid>(ex.Message);
        }


    }

}