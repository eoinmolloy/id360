﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface timedInputHandler : IEventSystemHandler {

	void HandleTimedInput();
}
