
#psutil(process and system utilities) is a cross - platform library
#for retrieving information on running processes and system utilization(CPU, memory, disks, network, sensors) in Python.It is useful mainly
#for system monitoring, profiling and limiting process resources and management of running processes.
import psutil
import functools
def print_result(func):
    functools.wraps(func)
    def wrapper_print_result(*args, **kwargs):
        result=func(*args,**kwargs)
        print(f"result: {result}")
        return result
    return wrapper_print_result

def repeat(num):
    def decorator_repeat(func):
        functools.wraps(func)
        def wrapper_repeat(*args,**kwargs):
            for _ in range(num):
                value=func(*args,**kwargs)
            return value
        return wrapper_repeat   
    return decorator_repeat #return a function object that can act as decorator

@repeat(3)
@print_result
def cpu_percent():
    return psutil.cpu_times_percent()
    
for proc in psutil.process_iter(attrs=['pid', 'name']):
    print(proc.info)
