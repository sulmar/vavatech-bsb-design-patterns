﻿namespace SimpleFactoryPattern
{
    // Concrete Product A
    public class NfzVisitCalculator : IVisitCalculator
    {
        public decimal CalculateCost(Visit visit)
        {
            return 0;
        }
    }

}
