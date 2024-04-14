using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TechOneTest.Server;

[Route("api/[controller]")]
[ApiController]
public class NumberConversionController : ControllerBase
{
    [HttpGet("{num}")]
    public async Task<ActionResult> ConvertNumberToWords([FromRoute] int num)
    {
        if (num == null) { 
            return
        }
        try
        {
            // Check if the input string is null or empty
            // Perform the conversion
            NumberConversion solution = new NumberConversion();
            string result = solution.NumberToWords(num);

            // Return the result
            return Ok(new { words = result });
        }
        catch (FormatException)
        {
            // Return a BadRequest response indicating invalid input
            return BadRequest("Input should be a valid number.");
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Return an appropriate error response
            return StatusCode(500, "An error occurred while converting number to words.");
        }
    }
}