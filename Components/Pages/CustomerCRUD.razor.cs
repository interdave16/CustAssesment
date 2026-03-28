using Microsoft.AspNetCore.Components;
using CustAssesment.Interfaces;
using Shared.Models;

namespace CustAssesment.Components.Pages;

public partial class CustomerCRUD
{
    [Inject]
    public ICustomerService CustomerService { get; set; } = default!;

    protected List<Customer> Customers { get; set; } = new();
    protected Customer CurrentCustomer { get; set; } = new();
    protected bool IsEditMode { get; set; }
    protected bool ShowCustomerModal { get; set; }
    protected bool ShowDeleteModal { get; set; }
    protected int DeleteCustomerId { get; set; }
    protected string DeleteCustomerName { get; set; } = string.Empty;
    protected string Message { get; set; } = string.Empty;
    protected string CustomerModalTitle => IsEditMode ? "Edit Customer" : "Add Customer";

    protected override async Task OnInitializedAsync()
    {
        await LoadCustomers();
    }

    protected async Task LoadCustomers()
    {
        Customers = await CustomerService.GetCustomersAsync();
    }

    protected void OpenNewCustomerModal()
    {
        ResetCurrentCustomer();
        IsEditMode = false;
        ClearMessage();
        ShowCustomerModal = true;
    }

    protected void OpenEditCustomerModal(Customer customer)
    {
        CurrentCustomer = CloneCustomer(customer);
        IsEditMode = true;
        ClearMessage();
        ShowCustomerModal = true;
    }

    protected void CloseCustomerModal()
    {
        ResetCurrentCustomer();
        IsEditMode = false;
        ShowCustomerModal = false;
    }

    protected async Task SaveCustomer()
    {
        if (IsEditMode)
        {
            var success = await CustomerService.UpdateCustomerAsync(CurrentCustomer);
            Message = success ? "Customer updated successfully." : "Update failed.";
        }
        else
        {
            var created = await CustomerService.CreateCustomerAsync(CurrentCustomer);
            Message = created is not null ? "Customer created successfully." : "Create failed.";
        }

        await LoadCustomers();
        CloseCustomerModal();
    }

    protected void OpenDeleteCustomerModal(Customer customer)
    {
        DeleteCustomerId = customer.Id;
        DeleteCustomerName = string.IsNullOrWhiteSpace(customer.Name)
            ? $"Customer {customer.Id}"
            : customer.Name;

        ShowDeleteModal = true;
    }

    protected void CloseDeleteModal()
    {
        DeleteCustomerId = 0;
        DeleteCustomerName = string.Empty;
        ShowDeleteModal = false;
    }

    protected async Task ConfirmDeleteCustomer()
    {
        var success = await CustomerService.DeleteCustomerAsync(DeleteCustomerId);
        Message = success ? "Customer deleted successfully." : "Delete failed.";

        await LoadCustomers();

        if (CurrentCustomer.Id == DeleteCustomerId)
        {
            CloseCustomerModal();
        }

        CloseDeleteModal();
    }

    private void ResetCurrentCustomer()
    {
        CurrentCustomer = new Customer();
    }

    private void ClearMessage()
    {
        Message = string.Empty;
    }

    private static Customer CloneCustomer(Customer customer)
    {
        return new Customer
        {
            Id = customer.Id,
            Name = customer.Name,
            City = customer.City,
            State = customer.State,
            Email = customer.Email
        };
    }
}