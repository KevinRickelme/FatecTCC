using System.Security.Claims;

namespace SI3.Utils
{
    public static class ClaimUtils
    {
        public static ClaimsPrincipal UpdateClaimsOfCurrentUser(ClaimsPrincipal User, string type, string value)
        {
            try
            {
                var user = User as ClaimsPrincipal;
                var identity = user.Identity as ClaimsIdentity;
                var claim = (from c in user.Claims
                             where c.Type == type
                             select c).Single();
                identity.RemoveClaim(claim);
                identity.AddClaim(new Claim(type, value));
                return user;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static ClaimsPrincipal AddNewClaimtoCurrentUser(ClaimsPrincipal User, string type, string value)
        {
            try
            {
                var user = User as ClaimsPrincipal;
                var identity = user.Identity as ClaimsIdentity;
                identity.AddClaim(new Claim(type, value));
                return user;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static string GetClaimInfo(ClaimsPrincipal identity, string type)
        {
            type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/"+type;
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            foreach (var item in identity.Claims)
            {
                if (item.Type == type)
                {
                    string temp = item.Value;
                    return temp;
                }
            }
            //Erro ao localizar a claim
            return "ClaimNaoEncontrada";
        }

        public static bool VerificaSeClaimExiste(ClaimsPrincipal identity, string type)
        {
            if (GetClaimInfo(identity, type) == "ClaimNaoEncontrada")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static void RemoveClaims(ClaimsPrincipal User)
        {
            try
            {
                var user = User as ClaimsPrincipal;
                var identity = user.Identity as ClaimsIdentity;
                var claim = (from c in user.Claims
                             select c).ToList();

                foreach(var clm in claim)
                    identity.RemoveClaim(clm);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
