using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;

namespace SFBoty.Mechanic.Areas {
	public class TarvernArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public TarvernArea()
			: base() {

		}

		public override void Initialize(Account.Account account, WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void Dispose() {
			base.Dispose();
		}

		//join tarvern
		//do quest
		//join tarvern (after quest finish)
		//goto char screen
		public override void PerformArea() {
			base.PerformArea();

			//if (Account.ALU_Seconds == 0 && !Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet && (!Account.Settings.BuyBeer || Account.Pilze == 0)) {
			//    RaiseMessageEvent("Keine Alu mehr");
			//    RaiseMessageEvent("Acc Alu: " + Account.ALU_Seconds.ToString() + " QuestStart: " + Account.QuestIsStarted.ToString());
			//    RaiseMessageEvent("StadtwacheStart: " + Account.StadtwacheWurdeGestatet.ToString());
			//    return;
			//}

			string s;
			if (!Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet) {
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinTarvern * 1000), (int)(Account.Settings.maxTimeToJoinTarvern * 1000)));
				RaiseMessageEvent("Tarverne betretten");
				s = SendRequest(ActionTypes.JoinTarvern);
				RaiseMessageEvent("Tarvern S-String: " + s);
				string[] answerTarvern = s.Split('/');

				int alu = Convert.ToInt32(answerTarvern[456]);
				Account.ALU_Seconds = alu;
				RaiseMessageEvent("Acc Alu: " + Account.ALU_Seconds.ToString() + " S-String Alu: " + answerTarvern[456]);

				if (Account.Settings.BuyBeer) {
					//answerTarvern[457] //usedBeerAmount
					//answerTarvern[108] //länge > 2 dann gibt es max 11 beer
					int usedBeer = Convert.ToInt32(answerTarvern[457]);
					int maxBeer = answerTarvern[108].Length > 2 ? 11 : 10;
					if (usedBeer < maxBeer && usedBeer < Account.Settings.MaxBeerToBuy && Account.ALU_Seconds <= 20 * 60) {
						while (Account.ALU_Seconds + 20 * 60 < 100 * 60 && Account.Pilze > 0) {
							Thread.Sleep(random.Next((int)(Account.Settings.minTimeToBuyBeer * 1000), (int)(Account.Settings.maxTimeToBuyBeer * 1000)));
							SendRequest(ActionTypes.BuyBeer);
							Account.ALU_Seconds += 20 * 60;
							usedBeer += 1;
							Account.Pilze -= 1;
							RaiseMessageEvent("Buy Beer " + usedBeer.ToString());
						}
					}
				}


				if (Account.ALU_Seconds == 0) {
					RaiseMessageEvent("Keine Alu mehr");
					return;
				}

				int quest1Dauer = Convert.ToInt32(answerTarvern[241]);
				int quest2Dauer = Convert.ToInt32(answerTarvern[242]);
				int quest3Dauer = Convert.ToInt32(answerTarvern[243]);

				int quest1XP = Convert.ToInt32(answerTarvern[280]);
				int quest2XP = Convert.ToInt32(answerTarvern[281]);
				int quest3XP = Convert.ToInt32(answerTarvern[282]);

				int quest1Gold = Convert.ToInt32(answerTarvern[283]);
				int quest2Gold = Convert.ToInt32(answerTarvern[284]);
				int quest3Gold = Convert.ToInt32(answerTarvern[285]);

				if (Account.Settings.PerformQuesten) {
					Thread.Sleep(random.Next((int)(Account.Settings.minTimeToTakeQuest * 1000), (int)(Account.Settings.maxTimeToTakeQuest * 1000)));
					switch (Account.Settings.QuestMode) {
						case AutoQuestMode.BestXP:
							int xpSecondQuest1 = quest1XP / quest1Dauer;
							int xpSecondQuest2 = quest2XP / quest2Dauer;
							int xpSecondQuest3 = quest3XP / quest3Dauer;
							if (xpSecondQuest1 >= xpSecondQuest2 && xpSecondQuest1 >= xpSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (xpSecondQuest2 >= xpSecondQuest1 && xpSecondQuest2 >= xpSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (xpSecondQuest3 >= xpSecondQuest1 && xpSecondQuest3 >= xpSecondQuest2) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= xpSecondQuest3;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
						case AutoQuestMode.BestGold:
							int goldSecondQuest1 = quest1Gold / quest1Dauer;
							int goldSecondQuest2 = quest2Gold / quest2Dauer;
							int goldSecondQuest3 = quest3Gold / quest3Dauer;
							if (goldSecondQuest1 >= goldSecondQuest2 && goldSecondQuest1 >= goldSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (goldSecondQuest2 >= goldSecondQuest1 && goldSecondQuest2 >= goldSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (goldSecondQuest3 >= goldSecondQuest1 && goldSecondQuest3 >= goldSecondQuest2) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
						case AutoQuestMode.BestTime:
							if (quest1Dauer <= quest2Dauer && quest1Dauer <= quest3Dauer) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (quest2Dauer <= quest1Dauer && quest2Dauer <= quest3Dauer) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (quest3Dauer <= quest1Dauer && quest3Dauer <= quest2Dauer) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
						case AutoQuestMode.HighstMountPerSecond:
							int _xpSecondQuest1 = quest1XP / quest1Dauer;
							int _xpSecondQuest2 = quest2XP / quest2Dauer;
							int _xpSecondQuest3 = quest3XP / quest3Dauer;
							int _goldSecondQuest1 = quest1Gold / quest1Dauer;
							int _goldSecondQuest2 = quest2Gold / quest2Dauer;
							int _goldSecondQuest3 = quest3Gold / quest3Dauer;
							if (GreaterThen(_xpSecondQuest1, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (GreaterThen(_xpSecondQuest2, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (GreaterThen(_xpSecondQuest3, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							} else if (GreaterThen(_goldSecondQuest1, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (GreaterThen(_goldSecondQuest2, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (GreaterThen(_goldSecondQuest3, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
					}
					RaiseMessageEvent("Quest ends " + Account.QuestEndTime.ToString());
					RaiseMessageEvent("Quest RequestString: " + s);
				}
			} else {
				if (DateTime.Now > Account.QuestEndTime && Account.QuestIsStarted) {
					Thread.Sleep(random.Next((int)(Account.Settings.minTimeToTakeQuest * 1000), (int)(Account.Settings.maxTimeToTakeQuest * 1000)));
					string t = SendRequest(ActionTypes.JoinTarvern);
					RaiseMessageEvent("Tarvern S-String: " + t);
					Thread.Sleep(random.Next((int)(Account.Settings.minTimeToEndAQuest * 1000), (int)(Account.Settings.maxTimeToEndAQuest * 1000)));
					string returnString = SendRequest(ActionTypes.JoinCharacter);
					Account.QuestIsStarted = false;
					RaiseMessageEvent("Quest was finished");

					CharScreenArea.UpdateAccountStats(returnString, Account);
				}
			}
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

		private bool GreaterThen(int source, params int[] targets) {
			bool returnValue = true;

			foreach (int a in targets) {
				if (source < a) {
					returnValue = false;
					break;
				}
			}

			return returnValue;
		}
	}

	public class MessageEventsArgs : EventArgs {
		public string Message { get; private set; }

		public MessageEventsArgs(string s) {
			Message = s;
		}
	}
}
/*
public void RefTavern(string name)
		{
			string keyValue = this.ini.GetKeyValue(name, "taveve");
			string tavernsetting = this.ini.GetKeyValue(name, "taverne");
			string keyValue2 = this.ini.GetKeyValue(name, "calcquestitems");
			string text = "";
			int angq = 0;
			int epq = 0;
			int goldq = 0;
			int num = 0;
			string keyValue3 = this.ini.GetKeyValue(name, "attrk");
			string keyValue4 = this.ini.GetKeyValue(name, "turm");
			if (keyValue3 == "2")
			{
				this.v.Waitings[name] = 1;
				string keyValue5 = this.ini.GetKeyValue(name, "attrkp");
				this.RefSkills(name, keyValue5);
			}
			if (keyValue4 == "1" && this.v.Towerisnotplayed[name].ToString() != "0")
			{
				this.RefTower(name);
				this.v.Towerisnotplayed[name] = 0;
			}
			this.v.Waitings[name] = 1;
			text = this.getHTML(name, "010", this.v);
			int millisecondsTimeout = new Random(DateTime.Now.Millisecond + 123).Next(100, 2000);
			Thread.Sleep(millisecondsTimeout);
			try
			{
				if (text == "")
				{
					text = this.getHTML(name, "010", this.v);
				}
				if (text.Substring(0, 4).Contains("103"))
				{
					this.writeLog(name, this.rm.GetString("Stadtwache erfolgreich beendet."), "INFO-STW");
					MethodInvoker method = delegate
					{
						this.wbtemp = null;
						this.updateLog(name, null, "---------;---------;----------;---------;--------", false);
					};
					base.BeginInvoke(method);
					text = this.getHTML(name, "004", this.v);
					int millisecondsTimeout2 = new Random(DateTime.Now.Millisecond + 123).Next(100, 2000);
					Thread.Sleep(millisecondsTimeout2);
					text = this.getHTML(name, "010", this.v);
					millisecondsTimeout2 = new Random(DateTime.Now.Millisecond + 99971).Next(100, 2000);
					Thread.Sleep(millisecondsTimeout2);
				}
				if (text.Substring(0, 4).Contains("106"))
				{
					text = this.getHTML(name, "004", this.v);
					int millisecondsTimeout3 = new Random(DateTime.Now.Millisecond + 123).Next(100, 2000);
					Thread.Sleep(millisecondsTimeout3);
					text = this.getHTML(name, "010", this.v);
				}
				millisecondsTimeout = new Random(DateTime.Now.Millisecond + 123).Next(Convert.ToInt32(this.ini.GetKeyValue(name, "min_time_short")), Convert.ToInt32(this.ini.GetKeyValue(name, "max_time_short")));
				Thread.Sleep(millisecondsTimeout);
				this.Recv01 = new char[]
				{
					' '
				};
				this.Recv01 = text.Split(new char[]
				{
					'/'
				});
				string questrem = "";
				try
				{
					if (text.Substring(0, 4).Contains("106"))
					{
						text = this.getHTML(name, "004", this.v);
						int millisecondsTimeout4 = new Random(DateTime.Now.Millisecond + 123).Next(100, 1000);
						Thread.Sleep(millisecondsTimeout4);
						text = this.getHTML(name, "010", this.v);
					}
					if (text.Substring(0, 4).Contains("107"))
					{
						this.v.endtime[name] = 0;
						this.v.action[name] = 0;
						this.v._action[name] = this.rm.GetString("Untätig");
						return;
					}
					this.Recv01 = new char[]
					{
						' '
					};
					this.Recv01 = text.Split(new char[]
					{
						'/'
					});
					Array array = text.Split(new char[]
					{
						';'
					});
					this.ini.SetKeyValue(name, "Event", array.GetValue(1).ToString());
					string text2 = Convert.ToString(Convert.ToInt32(this.Recv01.GetValue(456)) / 60);
					string text3 = Convert.ToString(Convert.ToInt64(this.Recv01.GetValue(28)), 2);
					for (int i = text3.Length; i < 32; i = text3.Length)
					{
						text3 = "0" + text3;
					}
					this.v.hasMirror[name] = text3.Substring(23, 1);
					this.Recv01.GetValue(28).ToString();
					string text4 = this.goldsilber(this.Recv01.GetValue(13), "Gold");
					int num2 = Convert.ToInt32(this.Recv01.GetValue(283));
					int num3 = Convert.ToInt32(this.Recv01.GetValue(284));
					int num4 = Convert.ToInt32(this.Recv01.GetValue(285));
					int num5 = Convert.ToInt32(this.Recv01.GetValue(280));
					int num6 = Convert.ToInt32(this.Recv01.GetValue(281));
					int num7 = Convert.ToInt32(this.Recv01.GetValue(282));
					int num8 = Convert.ToInt32(this.Recv01.GetValue(241));
					int num9 = Convert.ToInt32(this.Recv01.GetValue(242));
					int num10 = Convert.ToInt32(this.Recv01.GetValue(243));
					int num11 = Convert.ToInt32(this.Recv01.GetValue(268));
					int num12 = (num11 != 0) ? Convert.ToInt32(this.Recv01.GetValue(278)) : 0;
					int num13 = Convert.ToInt32(this.Recv01.GetValue(256));
					int num14 = (num13 != 0) ? Convert.ToInt32(this.Recv01.GetValue(266)) : 0;
					int num15 = Convert.ToInt32(this.Recv01.GetValue(244));
					int num16 = (num15 != 0) ? Convert.ToInt32(this.Recv01.GetValue(254)) : 0;
					if (keyValue2 == "1")
					{
						this.gzvq1 = ((num2 != 0) ? (((double)num2 + (double)num16) / (double)num8) : 0.0);
						this.gzvq2 = ((num2 != 0) ? (((double)num3 + (double)num14) / (double)num9) : 0.0);
						this.gzvq3 = ((num2 != 0) ? (((double)num4 + (double)num12) / (double)num10) : 0.0);
					}
					else
					{
						this.gzvq1 = ((num2 != 0) ? ((double)num2 / (double)num8) : 0.0);
						this.gzvq2 = ((num3 != 0) ? ((double)num3 / (double)num9) : 0.0);
						this.gzvq3 = ((num4 != 0) ? ((double)num4 / (double)num10) : 0.0);
					}
					int num17 = num5 / num8;
					int num18 = num6 / num9;
					int num19 = num7 / num10;
					goldq = 0;
					questrem = "";
					this.writeLog(name, this.rm.GetString("Taverne wird betreten..."), "INFO-TAV");
					MethodInvoker method2 = delegate
					{
						this.wbtemp = null;
						this.updateLog(name, this.Recv01, "-------;--------;--------;---------;--------;---------", true);
					};
					base.BeginInvoke(method2);
					string keyValue6;
					if (keyValue.ToString() == "1" && (keyValue6 = this.ini.GetKeyValue(name, "Event")) != null)
					{
						if (!(keyValue6 == "4"))
						{
							if (!(keyValue6 == "3"))
							{
								if (!(keyValue6 == "2"))
								{
									if (!(keyValue6 == "1"))
									{
										if (!(keyValue6 == "0"))
										{
										}
									}
									else
									{
										tavernsetting = "2";
									}
								}
								else
								{
									tavernsetting = "3";
								}
							}
							else
							{
								tavernsetting = "1";
							}
						}
						else
						{
							tavernsetting = "3";
						}
					}
					if (Convert.ToInt32(text2) <= 0 || text2 == "")
					{
						this.writeLog(name, this.rm.GetString("ALU leer.."), "INFO-TAV");
						MethodInvoker method3 = delegate
						{
							this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
						};
						base.BeginInvoke(method3);
						this.v.Waitings[name] = 1;
						this.RefBeer(name);
						this.v.Waitings[name] = 0;
					}
					else
					{
						if (Convert.ToInt32(text2) == 100)
						{
							this.RefBuySA(name);
							if (this.Recv01.GetValue(491).ToString() != "0")
							{
								string hTML = this.getHTML(name, "303", this.v);
								hTML.Split(new char[]
								{
									';'
								});
							}
							else
							{
								this.v.WCisdropped[name] = "2";
							}
							text = this.getHTML(name, "010", this.v);
						}
						if (Convert.ToInt32(text2) >= 90 && Convert.ToInt32(this.Recv01.GetValue(457)) == 0 && this.ini.GetKeyValue("Init", "BottleBuyOpt").ToString() == "1")
						{
							this.RefBottles(name, 0, "all");
							text = this.getHTML(name, "010", this.v);
						}
						if (tavernsetting.ToString() == "1")
						{
							if ((this.gzvq1 > this.gzvq2 && this.gzvq1 > this.gzvq3) || num15 == 11 || this.gzvq1 == this.gzvq2)
							{
								angq = 1;
								num = num8;
								goldq = num2;
								epq = num5;
								this.ggqvw = ((num14 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num16) : "") : "");
								if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
								{
									questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
								}
								else
								{
									if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
									{
										questrem = string.Concat(new string[]
										{
											" ",
											this.rm.GetString("Zusatz: Dungeonschlüssel"),
											" ",
											this.Recv01.GetValue(245).ToString(),
											" wurde gefunden :)"
										});
									}
									else
									{
										if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
										{
											questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
										}
									}
								}
							}
							if ((this.gzvq2 > this.gzvq1 && this.gzvq2 > this.gzvq3) || num13 == 11 || this.gzvq2 == this.gzvq3)
							{
								angq = 2;
								num = num9;
								goldq = num3;
								epq = num6;
								this.ggqvw = ((num14 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num14) : "") : "");
								if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
								{
									questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
								}
								else
								{
									if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
									{
										questrem = string.Concat(new string[]
										{
											" ",
											this.rm.GetString("Zusatz: Dungeonschlüssel"),
											" ",
											this.Recv01.GetValue(245).ToString(),
											" wurde gefunden :)"
										});
									}
									else
									{
										if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
										{
											questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
										}
									}
								}
							}
							if ((this.gzvq3 > this.gzvq1 && this.gzvq3 > this.gzvq2) || num11 == 11 || this.gzvq3 == this.gzvq2 || this.gzvq3 == this.gzvq1)
							{
								angq = 3;
								num = num10;
								goldq = num4;
								epq = num7;
								this.ggqvw = ((num12 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num12) : "") : "");
								if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
								{
									questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
								}
								else
								{
									if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
									{
										questrem = string.Concat(new string[]
										{
											" ",
											this.rm.GetString("Zusatz: Dungeonschlüssel"),
											" ",
											this.Recv01.GetValue(245).ToString(),
											" wurde gefunden :)"
										});
									}
									else
									{
										if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
										{
											questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
										}
									}
								}
							}
						}
						else
						{
							if (tavernsetting.ToString() == "2")
							{
								if ((num17 > num18 && num17 > num19) || num15 == 11 || num17 == num18)
								{
									angq = 1;
									num = num8;
									goldq = num2;
									epq = num5;
									this.ggqvw = ((num14 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num16) : "") : "");
									if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
									{
										questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
									}
									else
									{
										if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
										{
											questrem = string.Concat(new string[]
											{
												" ",
												this.rm.GetString("Zusatz: Dungeonschlüssel"),
												" ",
												this.Recv01.GetValue(245).ToString(),
												" wurde gefunden :)"
											});
										}
										else
										{
											if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
											{
												questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
											}
										}
									}
								}
								if ((num18 > num17 && num18 > num19) || num13 == 11 || num18 == num19)
								{
									angq = 2;
									num = num9;
									goldq = num3;
									epq = num6;
									this.ggqvw = ((num14 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num14) : "") : "");
									if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
									{
										questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
									}
									else
									{
										if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
										{
											questrem = string.Concat(new string[]
											{
												" ",
												this.rm.GetString("Zusatz: Dungeonschlüssel"),
												" ",
												this.Recv01.GetValue(245).ToString(),
												" wurde gefunden :)"
											});
										}
										else
										{
											if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
											{
												questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
											}
										}
									}
								}
								if ((num19 > num17 && num19 > num18) || num11 == 11 || num19 == num18 || num19 == num17)
								{
									angq = 3;
									num = num10;
									goldq = num4;
									epq = num7;
									this.ggqvw = ((num12 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num12) : "") : "");
									if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
									{
										questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
									}
									else
									{
										if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
										{
											questrem = string.Concat(new string[]
											{
												" ",
												this.rm.GetString("Zusatz: Dungeonschlüssel"),
												" ",
												this.Recv01.GetValue(245).ToString(),
												" wurde gefunden :)"
											});
										}
										else
										{
											if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
											{
												questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
											}
										}
									}
								}
							}
							else
							{
								if (tavernsetting.ToString() == "3")
								{
									if ((num8 > num9 && num8 > num10) || num15 == 11 || num8 == num9)
									{
										angq = 1;
										num = num8;
										goldq = num2;
										epq = num5;
										this.ggqvw = ((num14 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num16) : "") : "");
										if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
										{
											questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
										}
										else
										{
											if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
											{
												questrem = string.Concat(new string[]
												{
													" ",
													this.rm.GetString("Zusatz: Dungeonschlüssel"),
													" ",
													this.Recv01.GetValue(245).ToString(),
													" wurde gefunden :)"
												});
											}
											else
											{
												if (num15 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
												{
													questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
												}
											}
										}
									}
									if ((num9 > num8 && num9 > num10) || num13 == 11 || num9 == num10)
									{
										angq = 2;
										num = num9;
										goldq = num3;
										epq = num6;
										this.ggqvw = ((num14 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num14) : "") : "");
										if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
										{
											questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
										}
										else
										{
											if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
											{
												questrem = string.Concat(new string[]
												{
													" ",
													this.rm.GetString("Zusatz: Dungeonschlüssel"),
													" ",
													this.Recv01.GetValue(245).ToString(),
													" wurde gefunden :)"
												});
											}
											else
											{
												if (num13 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
												{
													questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
												}
											}
										}
									}
									if ((num10 > num8 && num10 > num9) || num11 == 11 || num10 == num9 || num10 == num8)
									{
										angq = 3;
										num = num10;
										goldq = num4;
										epq = num7;
										this.ggqvw = ((num12 != 0) ? ((keyValue2 == "1") ? string.Format(" (+ {0:#,#} Item)", num12) : "") : "");
										if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 42 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 30)
										{
											questrem = " " + this.rm.GetString("Zusatz: Spiegelstück wurde gefunden :)");
										}
										else
										{
											if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) <= 10 && Convert.ToInt32(this.Recv01.GetValue(245)) >= 1)
											{
												questrem = string.Concat(new string[]
												{
													" ",
													this.rm.GetString("Zusatz: Dungeonschlüssel"),
													" ",
													this.Recv01.GetValue(245).ToString(),
													" wurde gefunden :)"
												});
											}
											else
											{
												if (num11 == 11 && Convert.ToInt32(this.Recv01.GetValue(245)) == 20)
												{
													questrem = " " + this.rm.GetString("Zusatz: Kloschlüssel gefunden :)");
												}
											}
										}
									}
								}
							}
						}
						int num20 = Convert.ToInt32(this.ini.GetKeyValue(name, "attrk"));
						string keyValue7 = this.ini.GetKeyValue(name, "attrkp");
						int num21 = (text4.ToString() != "0") ? (Convert.ToInt32(text4) + Convert.ToInt32(this.goldsilber(goldq, "Gold"))) : Convert.ToInt32(this.goldsilber(goldq, "Gold"));
						if (num21 >= 1000000000)
						{
							if (num20 >= 1)
							{
								this.RefSkills(name, keyValue7);
								this.RefTavern(name);
							}
							else
							{
								MethodInvoker method4 = delegate
								{
									this.writeLog(name, this.rm.GetString("Taverne konnte nicht gestartet werden. Belohnung würde 100-Millionen-Grenze überschreiten"), "WARN-TAV");
									this.writeLog(name, "           " + this.rm.GetString("Bitte Attribute ausbauen, Items kaufen oder Gold spenden!"), "WARN-TAV");
								};
								base.BeginInvoke(method4);
							}
						}
						else
						{
							millisecondsTimeout = new Random(DateTime.Now.Millisecond + 123).Next(1000, 2000);
							Thread.Sleep(millisecondsTimeout);
							text = this.getHTML(name, "510" + angq + ";0", this.v);
							this.Recv01 = text.Split(new char[]
							{
								'/'
							});
							if (this.Recv01.GetValue(0).ToString().Contains("E086"))
							{
								if (this.ini.GetKeyValue(name, "SellCIF").ToString() == "1")
								{
									int num22 = this.Ref_Sell_Cheapest_Item_If_Invisfull(name, false);
									if (num22 != 999)
									{
										return;
									}
									if (!(this.ini.GetKeyValue(name, "tavernskipinv") == "1"))
									{
										this.writeLog(name, this.rm.GetString("Inventar ist voll! Bitte leeren oder in den Einstellungen die entsprechende Option setzen!"), "WARN-TAV");
										MethodInvoker method5 = delegate
										{
											this.wbtemp = null;
											this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
										};
										base.BeginInvoke(method5);
										return;
									}
									text = this.getHTML(name, "510" + angq + ";1", this.v);
									this.Recv01 = text.Split(new char[]
									{
										'/'
									});
									this.writeLog(name, this.rm.GetString("Achtung! Inventar ist voll! Aufgrund der entsprechenden Einstellung wurde der Quest trotzdem angenommen."), "WARN-TAV");
									MethodInvoker method6 = delegate
									{
										this.wbtemp = null;
										this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
									};
									base.BeginInvoke(method6);
								}
								else
								{
									if (!(this.ini.GetKeyValue(name, "tavernskipinv") == "1"))
									{
										this.writeLog(name, this.rm.GetString("Inventar ist voll! Bitte leeren oder in den Einstellungen die entsprechende Option setzen!"), "WARN-TAV");
										MethodInvoker method7 = delegate
										{
											this.wbtemp = null;
											this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
										};
										base.BeginInvoke(method7);
										return;
									}
									text = this.getHTML(name, "510" + angq + ";1", this.v);
									this.Recv01 = text.Split(new char[]
									{
										'/'
									});
									this.writeLog(name, this.rm.GetString("Achtung! Inventar ist voll! Aufgrund der entsprechenden Einstellung wurde der Quest trotzdem angenommen."), "WARN-TAV");
									MethodInvoker method8 = delegate
									{
										this.wbtemp = null;
										this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
									};
									base.BeginInvoke(method8);
								}
							}
							this.v.endtime[name] = Convert.ToInt32(this.Recv01.GetValue(47));
							this.v.action[name] = Convert.ToInt32(this.Recv01.GetValue(45));
							this.v._action[name] = "undefined";
							this.v.Begin[name] = ((this.v._action[name].ToString() == this.rm.GetString("Stadtwache")) ? (Convert.ToInt32(this.Recv01.GetValue(46)) * 60 * 60) : Convert.ToInt32(this.Recv01.GetValue(241 + Convert.ToInt32(this.Recv01.GetValue(46)) - 1)));
							switch (Convert.ToInt32(this.v.action[name]))
							{
							case 0:
								this.v._action[name] = this.rm.GetString("Untätig");
								break;
							case 1:
								this.v._action[name] = this.rm.GetString("Stadtwache");
								break;
							case 2:
								this.v._action[name] = this.rm.GetString("Questen");
								break;
							}
							TimeSpan tst = TimeSpan.FromSeconds((double)num);
							MethodInvoker method9 = delegate
							{
								this.lv_clicked_action_endtime_unix = Convert.ToInt32(this.v.endtime[name]);
								this.writeLog(name, this.rm.GetString("Gewählter Quest:"), "INFO-TAV");
								this.writeLog(name, string.Format(this.rm.GetString("Quest {0} nach Auswahlverfahren {1}"), angq, tavernsetting), "INFO-TAV");
								this.writeLog(name, string.Format(this.rm.GetString("Dauer: {0:D2}:{1:D2}:{2:D2}"), tst.Hours, tst.Minutes, tst.Seconds), "INFO-TAV");
								this.writeLog(name, string.Format(this.rm.GetString("Belohnung:{0:#,#} Silber{1} + {2:#,#} Erfahrung {3:#,#}"), new object[]
								{
									goldq,
									this.ggqvw,
									epq,
									questrem
								}), "INFO-TAV");
								this.updateLog(name, null, null, false);
							};
							base.BeginInvoke(method9);
						}
					}
				}
				catch (Exception ex)
				{
					this.writeLog(name, string.Format(this.rm.GetString("Ein Fehler ist aufgetreten... Code: " + text.Replace("+", "").Replace("E", "").Replace("0", "")), name), "ERRO-SF");
					Console.WriteLine(string.Format("FEHLER! Schleife 2 \n Account {0} \n Fehler: {1} \n letzte Rückgabe: {2}", name, ex.Data, text));
					MethodInvoker method10 = delegate
					{
						this.wbtemp = null;
						this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
					};
					base.BeginInvoke(method10);
				}
			}
			catch (Exception ex2)
			{
				this.writeLog(name, string.Format(this.rm.GetString("Ein Fehler ist aufgetreten... Code:") + text.Replace("+", "").Replace("E", "").Replace("0", ""), name), "ERRO-SF");
				Console.WriteLine(string.Format("FEHLER! Schleife 2 \n Account {0} \n Fehler: {1} \n letzte Rückgabe: {2}", name, ex2.Data, text));
				MethodInvoker method11 = delegate
				{
					this.wbtemp = null;
					this.updateLog(name, null, "-------;--------;--------;---------;--------;---------", true);
				};
				base.BeginInvoke(method11);
			}
			this.wbtemp = null;
			this.v.Waitings[name] = 0;
		}
*/