using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Application.AddSnake
{
    public class AddSnakeRequest : IRequest<AddSnakeRequest>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public float Point {  get; set; }
    }
}
