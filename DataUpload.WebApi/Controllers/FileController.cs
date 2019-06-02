using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataUpload.WebApi.Models;
using DataUpload.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transaction.Framework.Services.Interface;

namespace DataUpload.WebApi.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        //private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public FileController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            //_identityService = identityService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("test");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromBody] IEnumerable<FileModel> dataUploaded)
        {
            //var userId = _identityService.GetIdentity().UserId;
            return Ok();
            //var accountTransaction = _mapper.Map<AccountTransaction>(accountTransactionModel);
            //accountTransaction.TransactionType = TransactionType.Deposit;
            //var result = await _fileService.Deposit(accountTransaction);
            //return Created(string.Empty, _mapper.Map<TransactionResultModel>(result));
        }
    }
}
