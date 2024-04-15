# APBD_repo3

# refactoring-example
W tym zadaniu Waszym zadaniem jest modyfikacja kodu aplikacji nazwanej LegacyApp. Zakładamy, że jest to pewna spadkowa aplikacja i chcemy poprawić jakość jej kodu. Chcemy, aby kod w projekcie „LegacyAppConsumer” nie uległ modyfikacji. Innymi słowy kodu w tym projekcie nie możemy modyfikować.
Wszystko w projekcie LegacyApp może być modyfikowane – tak długo dopóki nie powoduje to zmiany interfejsu klas wykorzystywanych w projekcie LegacyAppConsumer. Dodatkowo nie można zmodyfikować klasy UserDataAccess i metody statycznej AddUser. Zakładamy, że w pewnych przyczyn nie możemy modyfikować tej klasy.


# PackageReferences
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.9.0" />
    <PackageReference Include="Moq" Version="4.20.70" />
    <PackageReference Include="NUnit" Version="4.1.0" />
    
