using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Orquestra3_SIAD.Business;

namespace SIAD_Monitoramento
{
    public partial class SIAD_Monitoramento : ServiceBase
    {
        public SIAD_Monitoramento()
        {
            InitializeComponent();

            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("SIADSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "SIADSource", "SIADLog");
            }
            eventLog1.Source = "SIADSource";
            eventLog1.Log = "SIADLog";

        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Iniciando o serviço SIAD Monitoramento. Ativando o timer de verificação.");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 30000; // 30 segundos
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventLog1.WriteEntry("SIAD Monitoramento iniciado");

            new DecisionSupport().monitorAndExecute(eventLog1);

            eventLog1.WriteEntry("SIAD Monitoramento finalizado");
            
        }

        protected override void OnStop()
        {
            
        }
    }
}
