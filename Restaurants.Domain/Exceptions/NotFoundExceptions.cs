namespace Restaurants.Domain.Exceptions;

public class NotFoundExceptions(string resourceType, string resourceIdentifier) 
    : Exception($"resource of type {resourceType} with identifier {resourceIdentifier} was not found.");