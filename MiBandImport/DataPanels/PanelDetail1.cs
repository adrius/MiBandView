﻿/**
 * Copyright (C) 2015 Ralf Joswig
 * 
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program;
 * if not, see <http://www.gnu.org/licenses/>
 */

using MiBand;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiBandImport.DataPanels
{
    class PanelDetail1 : MiBandDataPanel.MiBandPanel
    {
        private DataGridView dataGridView;

        protected override void showData()
        {
            // sind schon Daten vorhanden
            if (data == null)
            {
                return;
            }

            // neue Datenquelle für die Anzeige 
            List<MiBandUser> dataShow = new List<MiBandUser>();

            // Daten für die Filterung der Anzeige prüfen
            foreach (MiBandUser miData in data.userData)
            {
                // prüfen ob Daten im Zeitraum liegen
                if (miData.dateTime >= showFrom &&
                    miData.dateTime <= showTo)
                {
                    // ja, dann für Anzeige übernehmen
                    dataShow.Add(miData);
                }
            }

            // Daten in Grid einfügen
            dataGridView.DataSource = dataShow;

            // Grid für die modifizieren
            modifyDataGrid();
        }

        /// <summary>
        /// Eigene Komponenten initialisieren
        /// </summary>
        protected override void initOwnComponents()
        {
            // wenn nötig, den GridView erzeugen
            if (dataGridView == null)
            {
                dataGridView = new DataGridView();
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.BorderStyle = BorderStyle.Fixed3D;
                dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.Name = "dataGridViewPanel1";
                dataGridView.ReadOnly = true;

                this.Controls.Add(dataGridView);
            }
        }

        /// <summary>
        /// Anzeige mit den Einzeldaten aufbereiten
        /// </summary>
        private void modifyDataGrid()
        {
            // die einzelnen Datensätze untersuchen
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                // Spaltenbreite auf Optimum setzen
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // die Überschrift und ggf. die Sichtbarkeit der Spalten setzen
                switch (col.DataPropertyName)
                {
                    case "id":
                        col.HeaderText = Properties.Resources.ID;
                        col.Visible = false;
                        break;
                    case "dateTime":
                        col.HeaderText = Properties.Resources.DatumUhrzeit;
                        break;
                    case "type":
                        col.HeaderText = Properties.Resources.Typ;
                        break;
                    case "right":
                        col.HeaderText = Properties.Resources.Berechtigung;
                        col.Visible = false;
                        break;
                    case "index":
                        col.HeaderText = Properties.Resources.Index;
                        col.Visible = false;
                        break;
                    case "json_string":
                        col.HeaderText = Properties.Resources.JsonString;
                        col.Visible = false;
                        break;
                    case "script_version":
                        col.HeaderText = Properties.Resources.ScriptVersion;
                        col.Visible = false;
                        break;
                    case "lua_action_script":
                        col.HeaderText = Properties.Resources.LuaScript;
                        col.Visible = false;
                        break;
                    case "text1":
                        col.HeaderText = Properties.Resources.Schritte;
                        break;
                    case "dailyDistanceMeter":
                        col.HeaderText = Properties.Resources.Taetigkeit;
                        break;
                    case "text2":
                        col.HeaderText = Properties.Resources.Info;
                        break;
                    case "start":
                        col.HeaderText = Properties.Resources.Start;
                        col.Visible = false;
                        break;
                    case "stop":
                        col.HeaderText = Properties.Resources.Ende;
                        col.Visible = false;
                        break;
                    case "expire_time":
                        col.HeaderText = Properties.Resources.Ablaufzeit;
                        col.Visible = false;
                        break;
                    case "typeText":
                        col.HeaderText = Properties.Resources.Typ;
                        break;
                }
            }
        }
    }
}
