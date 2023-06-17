using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository.Authentication
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken, int>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
