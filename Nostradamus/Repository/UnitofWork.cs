using Microsoft.AspNetCore.Identity;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class UnitofWork
    {
        private NostradamusContext _nostradamusContext;
        //private readonly SignInManager<Noster> _signInManager;
        //private readonly UserManager<Noster> _userManager;

        public UnitofWork (
            NostradamusContext nostradamusContext
            //, 
            //SignInManager<Noster> signInManager, 
            //UserManager<Noster> userManager
            )
        {
            _nostradamusContext = nostradamusContext;
           // _signInManager = signInManager;
            //_userManager = userManager;
        }
    }
}
