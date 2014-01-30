using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;
using SFBotyCore.Mechanic;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
    public class HallOfFameArea : BaseArea {
        #region Events
        public override event EventHandler<MessageEventsArgs> MessageOutput;
        #endregion

        public HallOfFameArea()
            : base() {

        }

        public override void Initialize(Account.Account account, WebClient refClient) {
            base.Initialize(account, refClient);
        }

        public override void Dispose() {
            base.Dispose();
        }

        public override void PerformArea() {
            base.PerformArea();
        }

        public override void RaiseMessageEvent(string s) {
            if (MessageOutput != null) {
                MessageOutput(this, new MessageEventsArgs(s));
            }
        }
    }
}
