using JaseSmallProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Linq;

namespace JaseSmallProject.ViewModels
{
    public class OpenApiCallViewModel: BaseViewModel
    {
        private ApiCalls _apiCalls;
        public ObservableRangeCollection<Charger> Chargers { get; } = new ObservableRangeCollection<Charger>();
        public ICommand GetApiCommand { get; }
      

        public OpenApiCallViewModel()
        {
            _apiCalls = new ApiCalls();
            GetApiCommand = new AsyncCommand(DoGetApiCommand);
        }


        private async Task DoGetApiCommand()
        {
            var details = await _apiCalls.getapi();
            List<Charger> listdetails = details.ToList();
            Chargers.Add(listdetails.ElementAt(0));
            Chargers.Add(listdetails.ElementAt(1));
        }
    }

}
