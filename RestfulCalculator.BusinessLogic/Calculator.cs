namespace RestfulCalculator.BusinessLogic
{
    using RestfulCalculator.Interface.BusinessLogic;
    using RestfulCalculator.Resources;

    public class Calculator : ICalculator
    {
        /// <summary>
        /// Adds two decimal numbers.
        /// </summary>
        /// <param name="Number1">The first number to add.</param>
        /// <param name="Number2">The second number to add.</param>
        /// <returns>The result of adding the two numbers.</returns>
        //public Task<decimal> Add(decimal Number1, decimal Number2)
        //{
        //    return Task.Run(() => Number1 + Number2);
        //}
        public decimal Add(decimal Number1, decimal Number2)
        {
            return Number1 + Number2;
        }

        /// <summary>
        /// Subtracts one decimal number from another.
        /// </summary>
        /// <param name="Minuend">The number to subtract from.</param>
        /// <param name="Subtrahend">The number to subtract.</param>
        /// <returns>The result of subtracting the second number from the first.</returns>
        /// <exception cref="System.OverflowException">Thrown when the result is less than decimal.MinValue.</exception>
        public decimal Subtract(decimal Minuend, decimal Subtrahend)
        {
            decimal result = Minuend - Subtrahend;
            if (result < decimal.MinValue)
            {
                throw new System.OverflowException(ErrorMessages.SubtractionResultLessThanMinValue);
            }
            return result;
        }

        /// <summary>
        /// Multiplies two decimal numbers.
        /// </summary>
        /// <param name="Number1">The first number to multiply.</param>
        /// <param name="Number2">The second number to multiply.</param>
        /// <returns>The result of multiplying the two numbers.</returns>
        public decimal Multiply(decimal Number1, decimal Number2)
        {
            return Number1 * Number2;
        }

        /// <summary>
        /// Divides one decimal number by another.
        /// </summary>
        /// <param name="Dividend">The number to be divided.</param>
        /// <param name="Divisor">The number to divide by.</param>
        /// <returns>The result of dividing the first number by the second.</returns>
        /// <exception cref="System.DivideByZeroException">Thrown when the divisor is zero.</exception>
        public decimal Divide(decimal Dividend, decimal Divisor)
        {
            if (Divisor == 0)
            {
                throw new System.DivideByZeroException(ErrorMessages.DividByZero);
            }
            return Dividend / Divisor;
        }
    }

}