﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace WriteLog_Apps
{
    public static class WriteLogExtension
    {
        public static void WriteLog(this Exception ex, string startupPath)
        {
            StackTrace st = new StackTrace(ex, true);
            StackFrame frame = st.GetFrame(st.FrameCount - 1);
            File.AppendAllText(startupPath + "\\ErrorLog.txt", DateTime.Now.ToString("dd/MMM/yyyy HH:mm") + ": " + Path.GetFileName(frame.GetFileName()) + ": " + frame.GetMethod().Name + ": " + frame.GetFileLineNumber() + ", " + ex.Message + Environment.NewLine);
        }
        public static void WriteLog(this Exception ex)
        {
            var startupPath = new DirectoryInfo(Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path))).Parent.FullName;
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(st.FrameCount - 1);
            File.AppendAllText(startupPath + "\\ErrorLog.txt", DateTime.Now.ToString("dd/MMM/yyyy HH:mm") + ": " + Path.GetFileName(frame.GetFileName()) + ": " + frame.GetMethod().Name + ": " + frame.GetFileLineNumber() + ", " + ex.Message + Environment.NewLine);
        }
    }
}