' =======================================================
' Yet Another Process Monitor (YAPM)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yaprocmon/
' =======================================================


' YAPM is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Dim License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' YAPM is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Dim License for more details.
'
' You should have received a copy of the GNU General Dim License
' along with YAPM; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA


Option Strict On

Imports System.Runtime.InteropServices

Public Class cSystemInfo

    ' ========================================
    ' API declarations
    ' ========================================
    Private Structure PERFORMANCE_INFORMATION
        Dim Size As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> _
        Dim noNeed() As Integer          ' No need because informations are retrieved elsewhere
        Dim HandlesCount As Integer
        Dim ProcessCount As Integer
        Dim ThreadCount As Integer
    End Structure
    Private Structure SYSTEM_PERFORMANCE_INFORMATION
        Dim IdleTime As Long
        Dim IoReadTransferCount As Long
        Dim IoWriteTransferCount As Long
        Dim IoOtherTransferCount As Long
        Dim IoReadOperationCount As Integer
        Dim IoWriteOperationCount As Integer
        Dim IoOtherOperationCount As Integer
        Dim AvailablePages As Integer
        Dim CommittedPages As Integer
        Dim CommitLimit As Integer
        Dim PeakCommitment As Integer
        Dim PageFaults As Integer
        Dim CopyOnWriteFaults As Integer
        Dim TransitionFaults As Integer
        Dim CacheTransitionFaults As Integer
        Dim DemandZeroFaults As Integer
        Dim PagesRead As Integer
        Dim PagesReadIos As Integer
        Dim CacheRead As Integer
        Dim CacheReadIos As Integer
        Dim PagefilePagesWritten As Integer
        Dim PagefilePagesWriteIos As Integer
        Dim MappedFilePagesWritten As Integer
        Dim MappedFilePageWriteIos As Integer
        Dim PagedPoolUsage As Integer
        Dim NonPagedPoolUsage As Integer
        Dim PagedPoolAllocs As Integer
        Dim PagedPoolFrees As Integer
        Dim NonPagedPoolAllocs As Integer
        Dim NonPagedPoolFrees As Integer
        Dim FreeSystemPtes As Integer
        Dim SystemCodePages As Integer
        Dim TotalSystemDriverPages As Integer
        Dim TotalSystemCodePages As Integer
        Dim SmallNonPagedPoolLookasideListAllocateHits As Integer
        Dim SmallPagedPoolLookasideAllocateHits As Integer
        Dim Reserved3 As Integer
        Dim SystemCachePages As Integer
        Dim PagedPoolPages As Integer
        Dim SystemDriverPages As Integer
        Dim FastReadNoWait As Integer
        Dim FastReadWait As Integer
        Dim FastReadResourceMiss As Integer
        Dim FastReadNotPossible As Integer
        Dim FastMdlReadNoWait As Integer
        Dim FastMdlReadWait As Integer
        Dim FastMdlReadResourceMiss As Integer
        Dim FastMdlReadNotPossible As Integer
        Dim MapDataNoWait As Integer
        Dim MapDataWait As Integer
        Dim MapDataNoWaitMiss As Integer
        Dim MapDataWaitMiss As Integer
        Dim PinMappedDataCount As Integer
        Dim PinReadNoWait As Integer
        Dim PinReadWait As Integer
        Dim PinReadNoWaitMiss As Integer
        Dim PinReadWaitMiss As Integer
        Dim CopyReadNoWait As Integer
        Dim CopyReadWait As Integer
        Dim CopyReadNoWaitMiss As Integer
        Dim CopyReadWaitMiss As Integer
        Dim MdlReadNoWait As Integer
        Dim MdlReadWait As Integer
        Dim MdlReadNoWaitMiss As Integer
        Dim MdlReadWaitMiss As Integer
        Dim ReadAheadIos As Integer
        Dim LazyWriteIos As Integer
        Dim LazyWritePages As Integer
        Dim DataFlushes As Integer
        Dim DataPages As Integer
        Dim ContextSwitches As Integer
        Dim FirstLevelTbFills As Integer
        Dim SecondLevelTbFills As Integer
        Dim SystemCalls As Integer
    End Structure
    Private Structure SYSTEM_CACHE_INFORMATION
        Dim SystemCacheWsSize As Integer
        Dim SystemCacheWsPeakSize As Integer
        Dim SystemCacheWsFaults As Integer
        Dim SystemCacheWsMinimum As Integer
        Dim SystemCacheWsMaximum As Integer
        Dim TransitionSharedPages As Integer
        Dim TransitionSharedPagesPeak As Integer
        Dim Reserved1 As Integer
        Dim Reserved2 As Integer
    End Structure
    Private Structure SYSTEM_BASIC_INFORMATION
        Dim Reserved As Integer
        Dim TimerResolution As Integer
        Dim PageSize As Integer
        Dim NumberOfPhysicalPages As Integer
        Dim LowestPhysicalPageNumber As Integer
        Dim HighestPhysicalPageNumber As Integer
        Dim AllocationGranularity As Integer
        Dim MinimumUserModeAddress As Integer
        Dim MaximumUserModeAddress As Integer
        Dim ActiveProcessorsAffinityMask As Integer
        Dim NumberOfProcessors As Byte
    End Structure
    Public Enum SYSTEM_INFORMATION_CLASS As Integer
        SystemBasicInformation
        SystemProcessorInformation
        SystemPerformanceInformation
        SystemTimeOfDayInformation
        SystemNotImplemented1
        SystemProcessesAndThreadsInformation
        SystemCallCounts
        SystemConfigurationInformation
        SystemProcessorTimes
        SystemGlobalFlag
        SystemNotImplemented2
        SystemModuleInformation
        SystemLockInformation
        SystemNotImplemented3
        SystemNotImplemented4
        SystemNotImplemented5
        SystemHandleInformation
        SystemObjectInformation
        SystemPagefileInformation
        SystemInstructionEmulationCounts
        SystemInvalidInfoClass1
        SystemCacheInformation
        SystemPoolTagInformation
        SystemProcessorStatistics
        SystemDpcInformation
        SystemNotImplemented6
        SystemLoadImage
        SystemUnloadImage
        SystemTimeAdjustment
        SystemNotImplemented7
        SystemNotImplemented8
        SystemNotImplemented9
        SystemCrashDumpInformation
        SystemExceptionInformation
        SystemCrashDumpStateInformation
        SystemKernelDebuggerInformation
        SystemContextSwitchInformation
        SystemRegistryQuotaInformation
        SystemLoadAndCallImage
        SystemPrioritySeparation
        SystemNotImplemented10
        SystemNotImplemented11
        SystemInvalidInfoClass2
        SystemInvalidInfoClass3
        SystemTimeZoneInformation
        SystemLookasideInformation
        SystemSetTimeSlipEvent
        SystemCreateSession
        SystemDeleteSession
        SystemInvalidInfoClass4
        SystemRangeStartInformation
        SystemVerifierInformation
        SystemAddVerifier
        SystemSessionProcessesInformation
    End Enum
    Private Declare Function GetPerformanceInfo Lib "psapi.dll" (ByRef PerformanceInformation As PERFORMANCE_INFORMATION, ByVal Size As Integer) As Integer
    Private Declare Function ZwQuerySystemInformation Lib "ntdll.dll" (ByVal SystemInformationClass As SYSTEM_INFORMATION_CLASS, ByRef SystemInformation As SYSTEM_BASIC_INFORMATION, ByVal SystemInformationLength As Integer, ByRef ReturnLength As Integer) As Integer
    Private Declare Function ZwQuerySystemInformation Lib "ntdll.dll" (ByVal SystemInformationClass As SYSTEM_INFORMATION_CLASS, ByRef SystemInformation As SYSTEM_CACHE_INFORMATION, ByVal SystemInformationLength As Integer, ByRef ReturnLength As Integer) As Integer
    Private Declare Function ZwQuerySystemInformation Lib "ntdll.dll" (ByVal SystemInformationClass As SYSTEM_INFORMATION_CLASS, ByRef SystemInformation As SYSTEM_PERFORMANCE_INFORMATION, ByVal SystemInformationLength As Integer, ByRef ReturnLength As Integer) As Integer

    ' ========================================
    ' Private
    ' ========================================
    Private _handles As Integer
    Private _processes As Integer
    Private _threads As Integer
    Private _processors As Integer
    Private _physicalPagesCount As Integer
    Private _timerResolution As Integer
    Private _maxCache As Integer
    Private _currentCache As Integer
    Private _minCache As Integer
    Private _peakCache As Integer
    Private _cacheErrors As Integer

    ' ========================================
    ' Properties
    ' ========================================
    Public ReadOnly Property HandleCount() As Integer
        Get
            Return _handles
        End Get
    End Property
    Public ReadOnly Property ProcessCount() As Integer
        Get
            Return _processes
        End Get
    End Property
    Public ReadOnly Property ThreadCount() As Integer
        Get
            Return _threads
        End Get
    End Property
    Public ReadOnly Property ProcessorCount() As Integer
        Get
            Return _processors
        End Get
    End Property
    Public ReadOnly Property PhysicalPagesCount() As Integer
        Get
            Return _physicalPagesCount
        End Get
    End Property
    Public ReadOnly Property TimerResolution() As Integer
        Get
            Return _timerResolution
        End Get
    End Property
    Public ReadOnly Property CacheErrors() As Integer
        Get
            Return _cacheErrors
        End Get
    End Property
    Public ReadOnly Property CachePeak() As Integer
        Get
            Return _peakCache
        End Get
    End Property
    Public ReadOnly Property CacheMin() As Integer
        Get
            Return _minCache
        End Get
    End Property
    Public ReadOnly Property CacheCurrent() As Integer
        Get
            Return _currentCache
        End Get
    End Property
    Public ReadOnly Property CacheMax() As Integer
        Get
            Return _maxCache
        End Get
    End Property

    ' ========================================
    ' Public functions
    ' ========================================
    Public Sub New()
        MyBase.New()
        Call RefreshInfo()
    End Sub
    Public Sub RefreshInfo()
        Dim ret As Integer

        Dim pi As New PERFORMANCE_INFORMATION
        GetPerformanceInfo(pi, Marshal.SizeOf(pi))
        With pi
            _threads = .ThreadCount
            _handles = .HandlesCount
            _processes = .ProcessCount
        End With

        Dim ci As New SYSTEM_CACHE_INFORMATION
        ZwQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemCacheInformation, ci, Marshal.SizeOf(ci), ret)
        With ci
            _currentCache = .SystemCacheWsSize
            _peakCache = .SystemCacheWsPeakSize
            _cacheErrors = .SystemCacheWsFaults
            _minCache = .SystemCacheWsMinimum
            _maxCache = .SystemCacheWsMaximum
        End With

        Dim bi As New SYSTEM_BASIC_INFORMATION
        ZwQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemBasicInformation, bi, Marshal.SizeOf(bi), ret)
        With bi
            _physicalPagesCount = .NumberOfPhysicalPages
            _processors = .NumberOfProcessors
            _timerResolution = .TimerResolution
        End With

        Dim spi As New SYSTEM_PERFORMANCE_INFORMATION
        ZwQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemPerformanceInformation, spi, Marshal.SizeOf(spi), ret)
        With spi
            '
        End With

    End Sub

End Class