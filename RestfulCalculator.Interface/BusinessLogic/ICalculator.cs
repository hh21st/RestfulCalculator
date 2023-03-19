namespace RestfulCalculator.Interface.BusinessLogic
{

    /// <summary>
    /// Represents a basic calculator that performs four arithmetic operations.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Adds two decimal numbers and returns the result.
        /// </summary>
        /// <param name="number1">The first number to add.</param>
        /// <param name="number2">The second number to add.</param>
        /// <returns>The sum of <paramref name="number1"/> and <paramref name="number2"/>.</returns>
        /// <exception cref="OverflowException">Thrown when the result is outside the range of a decimal.</exception>
        decimal Add(decimal Number1, decimal Number2);

        /// <summary>
        /// Subtracts the second decimal number from the first and returns the result.
        /// </summary>
        /// <param name="minuend">The number to subtract from (the minuend).</param>
        /// <param name="subtrahend">The number to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="subtrahend"/> from <paramref name="minuend"/>.</returns>
        /// <exception cref="OverflowException">Thrown when the result of the operation is outside the range of a decimal value.</exception>
        decimal Subtract(decimal Minuend, decimal Subtrahend);

        /// <summary>
        /// Multiplies two decimal numbers and returns the result.
        /// </summary>
        /// <param name="factor1">The first number to multiply.</param>
        /// <param name="factor2">The second number to multiply.</param>
        /// <returns>The product of <paramref name="factor1"/> and <paramref name="factor2"/>.</returns>
        decimal Multiply(decimal Factor1, decimal Factor2);

        /// <summary>
        /// Divides the first decimal number by the second and returns the result.
        /// </summary>
        /// <param name="dividend">The number to divide (the dividend).</param>
        /// <param name="divisor">The number to divide by (the divisor).</param>
        /// <returns>The result of dividing <paramref name="dividend"/> by <paramref name="divisor"/>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="divisor"/> is zero.</exception>
        /// <exception cref="OverflowException">Thrown when the result is outside the range of a decimal.</exception>
        decimal Divide(decimal Dividend, decimal Divisor);
    }
}