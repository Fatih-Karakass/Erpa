using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Authentication
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken, int>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
