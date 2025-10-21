using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OneKickHeroes
{
    public partial class MainForm : Form
    {
        private readonly string superheroesFilePath;
        private readonly string summaryFilePath;

        public MainForm()
        {
            InitializeComponent();
            // Files saved in the application folder (you can change this)
            string appFolder = Application.StartupPath;
            superheroesFilePath = Path.Combine(appFolder, "superheroes.txt");
            summaryFilePath = Path.Combine(appFolder, "summary.txt");
        }

        // Hook this to your Generate Summary button
        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            GenerateSummaryReport();
        }

        /// <summary>
        /// Reads superheroes.txt, calculates statistics, displays summary on the form,
        /// and writes summary to summary.txt
        /// </summary>
        private void GenerateSummaryReport()
        {
            try
            {
                if (!File.Exists(superheroesFilePath))
                {
                    MessageBox.Show($"Data file not found: {superheroesFilePath}", "File Missing",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lines = File.ReadAllLines(superheroesFilePath)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToArray();

                if (lines.Length == 0)
                {
                    MessageBox.Show("No superhero records found in the data file.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lists to accumulate parsed numeric values
                List<int> ages = new List<int>();
                List<int> scores = new List<int>();
                int sCount = 0, aCount = 0, bCount = 0, cCount = 0;
                int totalRecords = 0;

                foreach (var raw in lines)
                {
                    // Allow fields to contain commas inside quoted strings is out-of-scope here.
                    // We assume simple CSV with no embedded commas. Trim spaces.
                    string[] parts = raw.Split(',').Select(p => p.Trim()).ToArray();

                    // Expected at least 5 fields: ID,Name,Age,Superpower,ExamScore
                    if (parts.Length < 5)
                    {
                        // skip malformed line but continue processing others
                        continue;
                    }

                    totalRecords++;

                    // Parse age safely
                    int ageParsed;
                    if (!int.TryParse(parts[2], out ageParsed))
                    {
                        // if age parse fails, skip adding it to average but continue
                        ageParsed = -1;
                    }
                    else
                    {
                        ages.Add(ageParsed);
                    }

                    // Parse exam score safely
                    int scoreParsed;
                    if (!int.TryParse(parts[4], out scoreParsed))
                    {
                        // if score missing or malformed, treat as 0 (or skip based on requirement)
                        // Here we skip adding malformed scores to averages but still count the record
                        continue;
                    }
                    else
                    {
                        // ensure score is within 0-100
                        if (scoreParsed < 0) scoreParsed = 0;
                        if (scoreParsed > 100) scoreParsed = 100;
                        scores.Add(scoreParsed);
                    }

                    // Determine rank from score (always based on score field)
                    string rank = DetermineRank(scoreParsed);
                    switch (rank)
                    {
                        case "S":
                            sCount++;
                            break;
                        case "A":
                            aCount++;
                            break;
                        case "B":
                            bCount++;
                            break;
                        case "C":
                            cCount++;
                            break;
                    }
                } // end foreach

                // Prepare computed statistics
                double avgAge = ages.Count > 0 ? ages.Average() : 0.0;
                double avgScore = scores.Count > 0 ? scores.Average() : 0.0;

                // Build summary text
                var summaryLines = new List<string>
                {
                    "One Kick Heroes Academy - Summary Report",
                    $"Generated on: {DateTime.Now:G}",
                    "----------------------------------------",
                    $"Total superhero records processed: {totalRecords}",
                    $"Total records with valid Age: {ages.Count}",
                    $"Average Age: {(ages.Count > 0 ? avgAge.ToString("F2") : "N/A")}",
                    $"Total records with valid Exam Score: {scores.Count}",
                    $"Average Exam Score: {(scores.Count > 0 ? avgScore.ToString("F2") : "N/A")}",
                    "",
                    "Heroes per Rank:",
                    $"S-Rank: {sCount}",
                    $"A-Rank: {aCount}",
                    $"B-Rank: {bCount}",
                    $"C-Rank: {cCount}",
                    "",
                    "Threat Levels:",
                    "S-Rank: Finals Week (threat to the entire academy)",
                    "A-Rank: Midterm Madness (threat to a department)",
                    "B-Rank: Group Project Gone Wrong (threat to a study group)",
                    "C-Rank: Pop Quiz (potential threat to an individual student)",
                };

                string summaryText = string.Join(Environment.NewLine, summaryLines);

                // Display on form: if you have a multiline TextBox named txtSummary
                if (this.Controls.ContainsKey("txtSummary"))
                {
                    var ctrl = this.Controls["txtSummary"] as TextBox;
                    if (ctrl != null)
                    {
                        ctrl.Clear();
                        ctrl.Text = summaryText;
                    }
                }
                else
                {
                    // alternative: show in a MessageBox (if no textbox available)
                    MessageBox.Show("Summary generated. Use a multiline TextBox named 'txtSummary' to display it on form.", "Summary Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Save to summary.txt
                File.WriteAllText(summaryFilePath, summaryText);

                // Optional: inform the user
                MessageBox.Show($"Summary generated and saved to:\n{summaryFilePath}", "Summary Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show($"Access denied while reading/writing files: {uex.Message}", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioex)
            {
                MessageBox.Show($"File I/O error: {ioex.Message}", "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error generating summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Determines hero rank based on the exam score using project rules.
        /// S-Rank: 81-100
        /// A-Rank: 61-80
        /// B-Rank: 41-60
        /// C-Rank: 0-40
        /// </summary>
        private string DetermineRank(int score)
        {
            if (score >= 81 && score <= 100) return "S";
            if (score >= 61 && score <= 80) return "A";
            if (score >= 41 && score <= 60) return "B";
            // For any score 0..40
            return "C";
        }
    }
}

