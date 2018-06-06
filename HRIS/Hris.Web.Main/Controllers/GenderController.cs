using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared.Gender;
using Hris.Web.Main.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hris.Web.Main.Controllers
{
    public class GenderController : Controller
    {
        private readonly IHrisListApi _hrisListApi;

        public GenderController(IHrisListApi hrisListApi)
        {
            _hrisListApi = hrisListApi;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var genders = await _hrisListApi.SelectGender(null);

            return Json(new ResponseResult<IEnumerable<GenderViewModel>>(genders));
        }
        [HttpPost]
        public async Task<IActionResult> Add(GenderViewModel gender)
        {
            var genderId = await _hrisListApi.SaveGender(gender);

            return Json(new ResponseResult<bool>(genderId > 0));
        }
        [HttpPost]
        public async Task<IActionResult> Update(GenderViewModel gender)
        {
            var genderId = await _hrisListApi.SaveGender(gender);

            return Json(new ResponseResult<bool>(genderId > 0));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var genderId = await _hrisListApi.DeleteGender(id);

            return Json(new ResponseResult<bool>(genderId > 0));
        }
        [HttpPost]
        public async Task<IActionResult> Status(int? id)
        {
            var genderId = await _hrisListApi.ToggleGenderStatus(id);

            return Json(new ResponseResult<bool>(genderId > 0));
        }
    }
}