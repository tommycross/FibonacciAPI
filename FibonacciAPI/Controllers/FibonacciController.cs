using Microsoft.AspNetCore.Mvc;

namespace FibonacciAPI;

[ApiController]
[Route("api/[controller]")]
public class FibonacciController : ControllerBase
{
    private readonly IFibonacciService _fibonacciService;

    public FibonacciController(IFibonacciService fibonacciService)
    {
        _fibonacciService = fibonacciService;
    }

    /// <summary>
    /// Gets the Fibonacci sequence up to a given length 
    /// </summary>
    /// <returns>The Fibonacci sequence</returns>
    // GET: api/fibonacci/5
    [HttpGet("{length}")]
    public async Task<IActionResult> GetFibonacciNumber(int length)
    {
        if (length < 0)
        {
            return BadRequest();
        }

        if (length > 95)
        {
            return BadRequest();
        }

        FibonacciSequenceResult sequence = new()
        {
            Result = await _fibonacciService.GetFibonacciSequenceAsync(length)
        };

        return Ok(sequence);
    }
}
