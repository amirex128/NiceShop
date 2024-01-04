using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Addresses.Queries.GetById;

public class GetAddressByIdHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<GetAddressByIdQuery, AddressDto>
{

    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.AddressRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<AddressDto>(result);
    }
}
