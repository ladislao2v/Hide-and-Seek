using System;

namespace Code.Services.ResourceBankService
{
    public interface IResourceBankService
    {
        int Value { get; }

        event Action<int> ValueChanged; 

        void Add(int value);
        void Spend(int value);
    }
}