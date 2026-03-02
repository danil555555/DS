namespace DS.Contracts;

public record CreateLocationRequest(
    string Name,
    string Country,
    string City,
    string Street,
    int StreetNumber,
    int Room,
    int PostalCode,
    string Timezone
    );