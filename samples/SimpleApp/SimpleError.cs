using PxBunny.Result;

namespace SimpleApp;

public class SimpleError(string message) : ErrorBase(message);
