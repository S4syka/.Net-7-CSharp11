//int? thisCouldBeNull = null;
//WriteLine(thisCouldBeNull);
//WriteLine(thisCouldBeNull.GetValueOrDefault());

//Nullable<int> thisCouldAlsoBeNull = null;
//thisCouldAlsoBeNull = 9;
//WriteLine(thisCouldAlsoBeNull);

using Packed.Shared;

Address address = new()
{
    Building = null,
    Street = null!,
    City = "London",
    Region = "UK"
};

WriteLine(address.Building?.Length);
WriteLine(address.Street.Length);