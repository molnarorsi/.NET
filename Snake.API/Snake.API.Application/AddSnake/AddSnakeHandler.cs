using MediatR;

namespace Snake.API.Application.AddSnake
{
    public class AddSnakeHandler : IRequestHandler<AddSnakeRequest, AddSnakeResponse>
    {
        public Task<AddSnakeResponse> Handle(AddSnakeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
