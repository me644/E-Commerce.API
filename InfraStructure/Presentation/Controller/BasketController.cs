using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.Contracts;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    public class BasketController(ISerivceMnager _serivceMnager) :ApiController
    {
        [HttpGet]
        public async Task<ActionResult<BasketDTO>> GetBasketAsync(string id)
        {
            return Ok(await _serivceMnager.BasketService.GetBasketAsync  (id));

        }

         [HttpPost]
        public async Task<ActionResult<BasketDTO>> CreateOrUpdateAsync(BasketDTO basketDTO)
        {

            return Ok(await _serivceMnager.BasketService.CreateOrUpdate(basketDTO));

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {

            await _serivceMnager.BasketService.DeleteAsync(id);
         
            return NoContent ();
        }
    }
}
