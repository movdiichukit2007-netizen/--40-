using PostService.Models;

namespace PostService.BusinessLogic;

public interface IPostingService
{
    List<Posting> GetAll();
    Posting? GetById(int id);
    Posting Create(Posting posting);
    bool Update(int id, Posting posting);
    bool Delete(int id);
}
