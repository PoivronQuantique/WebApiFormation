﻿using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository : Domain.ISelfieRepository
    {
        private readonly Contexte _Contexte = null;
        public DefaultSelfieRepository(Contexte contexte)
        {
            _Contexte = contexte;  
        }

        public ICollection<Selfie> GetAll()
        {
            return _Contexte.Selfies.Include(s=>s.Wookie).ToList();
        }
    }
}
