using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using React_assignment_1_web_api.Entity;
using React_assignment_1_web_api.Model;

namespace React_assignment_1_web_api.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderedController : Controller
    {
        private readonly EventDBContext _context;

        public FoodOrderedController (EventDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            if(_context.Food == null)
            {
                return NotFound();
            }

            var foods = (from f in _context.Food
                         select new
                         {
                             f.FoodID,
                             f.Name,
                             f.Info,
                             f.Price,
                         }).ToList();
            return Ok(foods);
        }

        [HttpGet("GetMealSummary")]
        public async Task<ActionResult<IEnumerable<MealSummery>>> GetMealSummary()
        {
            if (_context.MealSummery == null)
            {
                return NotFound();
            }

            var MealSummary = (from b in _context.MealSummery
                         select new
                         {
                             b.MealsummeryID,
                             b.MealSummeryTitle,
                             b.MealsummeryDescription_1,
                             b.MealsummeryDescription_2,
                            
                         }).ToList().FirstOrDefault();
            return Ok(MealSummary);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Food>>> PostOrder(OrderFood orderFood)
        {
            try
            {
                User user = orderFood.User;
                user.TotalAmount = orderFood.totalAmount;

                _context.User.Add(user);
                int res = await _context.SaveChangesAsync();

                int userId = _context.User.ToList().OrderByDescending(a => a.UserID).FirstOrDefault().UserID;

                if (userId > 0)
                {
                    foreach (var item in orderFood.items)
                    {
                        UserOrderedFood userOrderedFood = new UserOrderedFood();
                        userOrderedFood.UserID = userId;
                        userOrderedFood.FoodID = item.FoodID;
                        userOrderedFood.Quantity = item.Amount;
                        userOrderedFood.Price  = item.Price;

                        _context.UserOrderedFood.Add(userOrderedFood);
                        res = await _context.SaveChangesAsync();

                    }
                    if (res > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex  )
            {

                return BadRequest(ex.Message);  
            }
        }

        [HttpGet("GetUserData")]

        public ActionResult<IEnumerable<User>> GetUserData()

        {

            if (_context.User == null)

            {

                return NotFound();

            }

            var users = _context.User.ToList();

            return Ok(users);

        }

        [HttpGet("GetOrderDetails")]
        public ActionResult<IEnumerable<UserOrderedFood>> GetOrderDetails(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var orderData = from uf in _context.UserOrderedFood
                            join f in _context.Food on uf.FoodID equals f.FoodID
                            where uf.UserID == id
                            select new
                            {
                                f.Name,
                                uf.Price,
                                Total = uf.Price * uf.Quantity,
                                uf.Quantity
                            };

            return Ok(orderData);
        }

    }
}
