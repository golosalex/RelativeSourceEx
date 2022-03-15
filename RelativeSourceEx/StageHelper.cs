using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RelativeSourceEx
{
	[Flags]
	public enum ProcessStage
	{
		Stage1 = 0,
		Stage2 = 2,
		Stage3 = 4,
		Stage4 = 8,
		Stage5 = 16
	}
	public class StageHelper : DependencyObject
    {
		public static readonly DependencyProperty ProcessCompletionProperty = DependencyProperty.RegisterAttached(
		"ProcessCompletion", typeof(double), typeof(StageHelper), new PropertyMetadata(0.0, OnProcessCompletionChanged));

		private static readonly DependencyPropertyKey ProcessStagePropertyKey = DependencyProperty.RegisterAttachedReadOnly(
		"ProcessStage", typeof(ProcessStage), typeof(StageHelper), new PropertyMetadata(ProcessStage.Stage1));

		public static readonly DependencyProperty ProcessStageProperty = ProcessStagePropertyKey.DependencyProperty;

		private static void OnProcessCompletionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			double progress = (double)e.NewValue;
			ProgressBar bar = d as ProgressBar;
			if (progress >= 0 && progress < 20) bar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage1);
			if (progress >= 20 && progress < 40) bar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage2 | ProcessStage.Stage2);
			if (progress >= 40 && progress < 60) bar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage3);
			if (progress >= 60 && progress < 80) bar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage4);
			if (progress >= 80 && progress <= 100) bar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage5);
		}
		//[AttachedPropertyBrowsableForType(typeof(Control))]
		//public static ProcessStage GetProcessStage(ProgressBar bar)
  //      {
		//	if (bar == null) throw new ArgumentException("fignia");
		//	return (ProcessStage)bar.GetValue(ProcessStageProperty);
  //      }
		public static void SetProcessCompletion(ProgressBar bar, double progress)
		{
			bar.SetValue(ProcessCompletionProperty, progress);
		}

		public static void SetProcessStage(ProgressBar bar, ProcessStage stage)
		{
			bar.SetValue(ProcessStagePropertyKey, stage);
		}
	}
}
