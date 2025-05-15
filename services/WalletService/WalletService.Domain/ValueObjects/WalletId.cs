using CoreWallet.Shared.Domain;

namespace WalletService.Domain.ValueObjects
{
    public class WalletId : ValueObject
    {
        public Guid Value { get; }

        private WalletId(Guid value)
        {
            Value = value;
        }

        public static WalletId Create() => new(Guid.NewGuid());

        public static WalletId From(Guid id) => new(id);

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value.ToString();
    }
}
