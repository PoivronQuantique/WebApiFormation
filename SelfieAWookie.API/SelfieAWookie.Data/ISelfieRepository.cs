using SelfieAWookie.Core.Selfies.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Domain
{
    public interface ISelfieRepository : IRepository
    {
        public ICollection<Selfie> GetAll(int WookieId);
        public Selfie AddOne(Selfie newSelfie);
        public Photo AddOnePhoto(string newPhoto);
    }
}
