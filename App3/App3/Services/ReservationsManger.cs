//#define ReservationsManager
using App3.Models;
using App3.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Services
{
#if ReservationsManager
    // Azure
    public class ReservationsManager
    { 
    private IMobileServiceTable<Reservations> __ReservationsTable;
    private MobileServiceClient _client;

    private ReservationsViewModels _ReservationsViewModel = new ReservationsViewModels();
    private bool _checkBoxClicked = false;

    public ReservationsViewModels ReservationsViewModel
        {
        get { return this._ReservationsViewModel; }
    }

    public bool CheckBoxClicked
    {
        get { return this._checkBoxClicked; }
        set { _checkBoxClicked = value; }
    }
    public ReservationsManager()
    {
           this._client = new MobileServiceClient(Constants.ApplicationURL);

        this.__ReservationsTable = _client.GetTable<Reservations>();
        App.SetReservationsManager(this);
    }
    public Reservations GetTaskFromList(string id)
    {
        return ReservationsViewModel.ReservationsItems.FirstOrDefault(o => o.ID == id);
    }
    public async Task<Reservations> GetTaskAsync(string id)
    {
        try
        {
            return await __ReservationsTable.LookupAsync(id);
        }
        catch (MobileServiceInvalidOperationException msioe)
        {
            Debug.WriteLine(@"INVALID {0}", msioe.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"ERROR {0}", e.Message);
        }
        return null;
    }
    public async Task<ObservableCollection<Reservations>> GetTasksAsync()
    {
        try
        {
            return new ObservableCollection<Reservations>(await __ReservationsTable.ReadAsync());
        }
        catch (MobileServiceInvalidOperationException msioe)
        {
            Debug.WriteLine(@"INVALID {0}", msioe.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"ERROR {0}", e.Message);
        }
        return null;
    }
    public async Task SaveTaskAsync(Reservations item)
    {
        if (item.ID == null)
        {
            await __ReservationsTable.InsertAsync(item);
                ReservationsViewModel.ReservationsItems.Add(item);
        }
        else
            await __ReservationsTable.UpdateAsync(item);
    }
    public async Task DeleteTaskAsync(Reservations item)
    {
        try
        {
                ReservationsViewModel.ReservationsItems.Remove(item);
            await __ReservationsTable.DeleteAsync(item);
        }
        catch (MobileServiceInvalidOperationException msioe)
        {
            Debug.WriteLine(@"INVALID {0}", msioe.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"ERROR {0}", e.Message);
        }
    }
}
#endif
}
