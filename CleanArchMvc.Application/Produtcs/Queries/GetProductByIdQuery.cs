using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Produtcs.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}