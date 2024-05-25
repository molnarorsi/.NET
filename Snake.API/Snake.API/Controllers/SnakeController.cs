using MediatR;
using Microsoft.AspNetCore.Mvc;
using Snake.API.Application.AddSnake;

namespace Snake.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SnakeController : ControllerBase
	{
		private IMediator mediator;
		public SnakeController(IMediator mediator) 
		{ 
			this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		[HttpGet, Route("Test")]
		public async Task<IActionResult> Test(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpPost, Route("AddSnake")]
		public async Task<IActionResult> AddSnake(AddSnakeRequest request, CancellationToken cancellationToken)
		{
			var response = this.mediator.Send(request ?? new AddSnakeRequest(), cancellationToken);
			return this.Ok(response);
		}

	}

	
}
