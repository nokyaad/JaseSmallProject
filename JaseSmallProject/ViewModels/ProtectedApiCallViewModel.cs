using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using JaseSmallProject.Models;
using Microsoft.Identity.Client;
using System.Windows.Input;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace JaseSmallProject.ViewModels
{
    public class ProtectedApiCallViewModel: BaseViewModel
    {
        private ProtectedApiCalls _protectedApiCalls;
        
        public ObservableRangeCollection<Charger> Chargers { get; } = new ObservableRangeCollection<Charger>();
        public ICommand GetProtectedApiCommand;
        
        public ProtectedApiCallViewModel()
        {
            
            _protectedApiCalls = new ProtectedApiCalls();
            GetProtectedApiCommand = new AsyncCommand(DoGetProtectecApiCommand);
        }

        private async Task DoGetProtectecApiCommand()
        {
            var details = await _protectedApiCalls.getprotectedapi();
            Chargers.Add(details);
        }
    }
}
