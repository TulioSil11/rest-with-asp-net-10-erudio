using FluentAssertions;
using Moq;
using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Models.DTOs;
using RestWithASPNET10Erudio.Repositories.Interfaces;
using RestWithASPNET10Erudio.Service;

namespace RestWithASPNET10Erudio.Tests.Services
{
	public class PersonServiceTests
	{
		private readonly Mock<IRepository<Person>> _repositoryMock;
		private readonly PersonService _service;

		public PersonServiceTests()
		{
			_repositoryMock = new Mock<IRepository<Person>>();
			_service = new PersonService(_repositoryMock.Object);
		}

		[Fact]
		public void GetAll_ShouldReturnAllPeople()
		{
			// Arrange
			var people = new List<Person>
			{
				new Person
				{
					Id = Guid.NewGuid(),
					FirstName = "Túlio",
					LastName = "Silva"
				},
				new Person
				{
					Id = Guid.NewGuid(),
					FirstName = "João",
					LastName = "Oliveira"
				}
			};

			_repositoryMock
				.Setup(repository => repository.GetAll())
				.Returns(people);

			// Act
			var result = _service.GetAll();

			// Assert
			result.Should().NotBeNull();
			result.Should().HaveCount(2);

			result[0].FirstName.Should().Be("Túlio");
			result[0].LastName.Should().Be("Silva");

			result[1].FirstName.Should().Be("João");
			result[1].LastName.Should().Be("Oliveira");

			_repositoryMock.Verify(
				repository => repository.GetAll(),
				Times.Once);
		}

		[Fact]
		public void GetById_ShouldReturnPerson()
		{
			// Arrange
			var id = Guid.NewGuid();

			var person = new Person
			{
				Id = id,
				FirstName = "Túlio",
				LastName = "Silva"
			};

			_repositoryMock
				.Setup(repository => repository.GetById(id))
				.Returns(person);

			// Act
			var result = _service.GetById(id);

			// Assert
			result.Should().NotBeNull();
			result.Id.Should().Be(id);
			result.FirstName.Should().Be("Túlio");
			result.LastName.Should().Be("Silva");

			_repositoryMock.Verify(
				repository => repository.GetById(id),
				Times.Once);
		}

		[Fact]
		public void Create_ShouldCreatePerson()
		{
			// Arrange
			var personDto = new PersonDTO
			{
				Id = Guid.NewGuid(),
				FirstName = "Túlio",
				LastName = "Silva"
			};

			// Act
			_service.Create(personDto);

			// Assert
			_repositoryMock.Verify(
				repository => repository.Create(
					It.Is<Person>(person =>
						person.Id == personDto.Id &&
						person.FirstName == personDto.FirstName &&
						person.LastName == personDto.LastName
					)),
				Times.Once);
		}

		[Fact]
		public void Update_ShouldUpdatePerson()
		{
			// Arrange
			var personDto = new PersonDTO
			{
				Id = Guid.NewGuid(),
				FirstName = "Túlio",
				LastName = "Silva"
			};

			// Act
			_service.Update(personDto);

			// Assert
			_repositoryMock.Verify(
				repository => repository.Update(
					It.Is<Person>(person =>
						person.Id == personDto.Id &&
						person.FirstName == personDto.FirstName &&
						person.LastName == personDto.LastName
					)),
				Times.Once);
		}

		[Fact]
		public void Delete_ShouldDeletePerson()
		{
			// Arrange
			var id = Guid.NewGuid();

			// Act
			_service.Delete(id);

			// Assert
			_repositoryMock.Verify(
				repository => repository.Delete(id),
				Times.Once);
		}
	}
}