using LeveransAkuten.Models.Entities;

namespace LeveransAkuten.Models.Services
{
    public class HomeService
    {
        BudIdentityContext identityCtx;

        public HomeService(BudIdentityContext identityCtx)
        {
            this.identityCtx = identityCtx;
        }

        public void BuildIdentityDb()
        {
            identityCtx.Database.EnsureCreated();
        }
    }
}
